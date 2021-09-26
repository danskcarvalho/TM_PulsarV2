using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Newtonsoft.Json;
using Pulsar.Common.Cqrs;
using Pulsar.Common.Database;
using Pulsar.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Jobs
{
    public class JobConsumer
    {
        public JobProducer Producer { get; }
        public IConfiguration Configuration { get; }
        public ICommandBus CommandBus { get; }

        public JobConsumer(IConfiguration configuration, JobProducer producer, ICommandBus commandBus)
        {
            this.Producer = producer;
            this.Configuration = configuration;
            this.CommandBus = commandBus;
        }

        public async Task Run(CancellationToken ct)
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    if (ct.IsCancellationRequested)
                        break;
                    try
                    {
                        await PopAndRunJob(ct);
                    }
                    catch (TaskCanceledException)
                    {
                        if (ct.IsCancellationRequested)
                            break;
                    }
                    catch
                    {
                        //TODO: log exception...
                        await Task.Delay(1000);
                    }
                }
            });
        }

        private async Task PopAndRunJob(CancellationToken ct)
        {
            var job = await Producer.Pop(ct);
            var factory = new MongoContextFactory(this.Configuration);
            //only initializes the job if its pending
            bool bInitialized = await TryInitializeJob(job, factory);
            if (bInitialized)
            {
                //test if job is pending for too long...
                //if the job is scheduled
                if (DateTime.Now > job.ScheduledForExecution.AddMilliseconds(JobConstants.PendingTimeout))
                {
                    await JobHasExpiredPendingTimeout(job, factory);
                    return;
                }

                bool bFinished = false;
                try
                {
                    //run the job
                    await RunJob(job, ct);
                    bFinished = true;
                }
                catch (TimeoutException e)
                {
                    await FinishJobWithTimeoutException(job, e, factory);
                }
                catch (Exception e)
                {
                    await FinishJobWithException(job, e, factory);
                }

                if (bFinished)
                    await FinishJob(job, factory);
            }
            else
            {
                //test if the job is in executing status for too long...
                if (job.Status == Common.Jobs.JobStatus.Executing && job.StartedExecutionOn != null)
                {
                    if (DateTime.Now > job.StartedExecutionOn.Value.AddMilliseconds(JobConstants.ExecutingTimeout))
                        await JobHasExpiredExecutingTimeout(job, factory);

                    return;
                }
            }
        }

        private async Task FinishJobWithTimeoutException(JobModel job, TimeoutException e, MongoContextFactory factory)
        {
            await factory.Start(async ctx =>
            {
                var collection = ctx.GetCollection<JobModel>(JobConstants.CollectionName);
                var u = await collection.UpdateOneAsync(ctx.Session, j => j.Id == job.Id,
                    Builders<JobModel>.Update
                        .Set(j => j.Status, Common.Jobs.JobStatus.Error)
                        .Set(j => j.EndedExecutionOn, DateTime.Now)
                        .Set(j => j.ErrorCategory, Common.Jobs.JobErrorCategory.ExecutionTimeout)
                        .Set(j => j.ExceptionJson, ToJson(e))
                    );
            }, IsolationOptions.Committed);
        }

        private async Task FinishJobWithException(JobModel job, Exception e, MongoContextFactory factory)
        {
            await factory.Start(async ctx =>
            {
                var collection = ctx.GetCollection<JobModel>(JobConstants.CollectionName);
                var u = await collection.UpdateOneAsync(ctx.Session, j => j.Id == job.Id,
                    Builders<JobModel>.Update
                        .Set(j => j.Status, Common.Jobs.JobStatus.Error)
                        .Set(j => j.EndedExecutionOn, DateTime.Now)
                        .Set(j => j.ErrorCategory, Common.Jobs.JobErrorCategory.Exception)
                        .Set(j => j.ExceptionJson, ToJson(e))
                    );
            }, IsolationOptions.Committed);
        }

        private string ToJson(Exception e)
        {
            try
            {
                return JsonConvert.SerializeObject(e, new JsonSerializerSettings());
            }
            catch
            {
                return JsonConvert.SerializeObject(new { Type = e.GetType().FullName, e.Message, e.StackTrace }, new JsonSerializerSettings());
            }
        }

        private async Task FinishJob(JobModel job, MongoContextFactory factory)
        {
            await factory.Start(async ctx =>
            {
                var collection = ctx.GetCollection<JobModel>(JobConstants.CollectionName);
                var u = await collection.UpdateOneAsync(ctx.Session, j => j.Id == job.Id,
                    Builders<JobModel>.Update
                        .Set(j => j.Status, Common.Jobs.JobStatus.Done)
                        .Set(j => j.EndedExecutionOn, DateTime.Now)
                    );
            }, IsolationOptions.Committed);
        }

        private async Task RunJob(JobModel job, CancellationToken ct)
        {
            CancellationTokenSource timeoutSource = new CancellationTokenSource();
            timeoutSource.CancelAfter(TimeSpan.FromMilliseconds(JobConstants.ExecutionTimeout));
            var finalToken = CancellationTokenSource.CreateLinkedTokenSource(timeoutSource.Token, ct);
            var cmd = JobDiscriminator.GetJob(job.Discriminator, job.Command);
            await Task.Run(async () => await (CommandBus as ISlowCommandBus).Send(cmd, finalToken.Token), finalToken.Token);
        }

        private async Task JobHasExpiredPendingTimeout(JobModel job, MongoContextFactory factory)
        {
            await factory.Start(async ctx =>
            {
                var collection = ctx.GetCollection<JobModel>(JobConstants.CollectionName);
                var u = await collection.UpdateOneAsync(ctx.Session, j => j.Id == job.Id,
                    Builders<JobModel>.Update
                        .Set(j => j.Status, Common.Jobs.JobStatus.Error)
                        .Set(j => j.EndedExecutionOn, DateTime.Now)
                        .Set(j => j.ErrorCategory, Common.Jobs.JobErrorCategory.PendingTimeout)
                    );
            }, IsolationOptions.Committed);
        }

        private async Task JobHasExpiredExecutingTimeout(JobModel job, MongoContextFactory factory)
        {
            await factory.Start(async ctx =>
            {
                var collection = ctx.GetCollection<JobModel>(JobConstants.CollectionName);
                var u = await collection.UpdateOneAsync(ctx.Session, j => j.Id == job.Id,
                    Builders<JobModel>.Update
                        .Set(j => j.Status, Common.Jobs.JobStatus.Error)
                        .Set(j => j.EndedExecutionOn, DateTime.Now)
                        .Set(j => j.ErrorCategory, Common.Jobs.JobErrorCategory.ExecutingTimeout)
                    );
            }, IsolationOptions.Committed);
        }

        private async Task<bool> TryInitializeJob(JobModel job, MongoContextFactory factory)
        {
            if (job.Status != Common.Jobs.JobStatus.Pending)
                return false;

            return await factory.StartWithResponse(async ctx =>
            {
                var collection = ctx.GetCollection<JobModel>(JobConstants.CollectionName);
                var u = await collection.UpdateOneAsync(ctx.Session, j => j.Status == Common.Jobs.JobStatus.Pending
                    && j.Id == job.Id && (j.ScheduledForExecution == null || DateTime.Now > j.ScheduledForExecution),
                    Builders<JobModel>.Update
                        .Set(j => j.Status, Common.Jobs.JobStatus.Executing)
                        .Set(j => j.StartedExecutionOn, DateTime.Now)
                    );
                return u.IsAcknowledged && u.ModifiedCount == 1;
            }, IsolationOptions.Committed);
        }
    }
}
