using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
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
    public class JobProducer
    {
        private Queue<JobModel> _Queue = new Queue<JobModel>();
        private HashSet<ObjectId> _JobsInQueue = new HashSet<ObjectId>();
        public IConfiguration Configuration { get; }

        public JobProducer(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public async Task Run(CancellationToken ct)
        {
            var w = WatchChanges(ct);
            var p = PollChanges(ct);
            await Task.WhenAll(w, p);
        }
        public async Task<JobModel> Pop(CancellationToken ct)
        {
            while (true)
            {
                if (ct.IsCancellationRequested)
                    throw new TaskCanceledException();
                await Task.Delay(1000);
                lock (_Queue)
                {
                    if (_Queue.Count == 0)
                        continue;

                    var j = _Queue.Dequeue();
                    _JobsInQueue.Remove(j.Id);
                    return j;
                }
            }
        }

        private async Task PollChanges(CancellationToken ct)
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    if (ct.IsCancellationRequested)
                        break;
                    try
                    {
                        await Task.Delay(JobConstants.PollingTimeout, ct);
                        var factory = new MongoContextFactory(Configuration);
                        //watch changes
                        await factory.Start(async ctx =>
                        {

                            while (true)
                            {
                                if (ct.IsCancellationRequested)
                                    break;
                                try
                                {
                                    var collection = ctx.GetCollection<JobModel>(JobConstants.CollectionName);
                                    var jobs = await (await collection
                                        .FindAsync(ctx.Session,
                                            j => (j.Status == Common.Jobs.JobStatus.Pending || j.Status == Common.Jobs.JobStatus.Executing) &&
                                                 (j.ScheduledForExecution == null || DateTime.Now > j.ScheduledForExecution),
                                            new FindOptions<JobModel, JobModel>()
                                            {
                                                Limit = JobConstants.MaxJobs
                                            })).ToListAsync();
                                    foreach (var j in jobs)
                                    {
                                        if (ct.IsCancellationRequested)
                                            break;
                                        if (j.MayNeedProcessing())
                                            TryProcess(j);
                                    }
                                    break;
                                }
                                catch (TaskCanceledException)
                                {
                                    if (ct.IsCancellationRequested)
                                        break;
                                }
                                catch
                                {
                                    await Task.Delay(1000);
                                }
                            }
                        });
                    }
                    catch (TaskCanceledException)
                    {
                        if (ct.IsCancellationRequested)
                            break;
                    }
                    catch
                    {
                        await Task.Delay(1000);
                    }
                }
            });
        }
        private async Task WatchChanges(CancellationToken ct)
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    if (ct.IsCancellationRequested)
                        break;
                    try
                    {
                        var factory = new MongoContextFactory(Configuration);
                        //watch changes
                        await factory.Start(async ctx =>
                        {

                            while (true)
                            {
                                if (ct.IsCancellationRequested)
                                    break;
                                try
                                {
                                    var collection = ctx.GetCollection<JobModel>(JobConstants.CollectionName);
                                    var pipeline =
                                        new EmptyPipelineDefinition<ChangeStreamDocument<JobModel>>()
                                        .Match(x => x.OperationType == ChangeStreamOperationType.Insert);
                                    using (var cursor = await collection.WatchAsync(ctx.Session, pipeline))
                                    {
                                        await cursor.ForEachAsync(change =>
                                        {
                                            if (change.FullDocument.MayNeedProcessing())
                                                TryProcess(change.FullDocument);
                                        }, ct);
                                    }
                                }
                                catch (TaskCanceledException)
                                {
                                    if (ct.IsCancellationRequested)
                                        break;
                                }
                                catch
                                {
                                    await Task.Delay(1000);
                                }
                            }
                        });
                    }
                    catch (TaskCanceledException)
                    {
                        if (ct.IsCancellationRequested)
                            break;
                    }
                    catch
                    {
                        await Task.Delay(1000);
                    }
                }
            });
        }

        private void TryProcess(JobModel job)
        {
            lock (_Queue)
            {
                if (_JobsInQueue.Contains(job.Id))
                    return;

                _Queue.Enqueue(job);
                _JobsInQueue.Add(job.Id);
            }
        }
    }
}
