using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using Pulsar.Common.Cqrs;
using Pulsar.Common.Database;
using Pulsar.Common.Jobs;
using Pulsar.Common.Services;
using Pulsar.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Jobs
{
    public class JobService : IJobService
    {
        private readonly IConfiguration Configuration = null;

        public JobService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        Task IJobService.Push<T>(T cmd)
        {
            return CreateJob(cmd, DateTime.Now);
        }

        Task IJobService.Schedule<T>(DateTime on, T cmd)
        {
            return CreateJob(cmd, on);
        }

        private async Task CreateJob(ICommand cmd, DateTime scheduledOn)
        {
            var factory = new MongoContextFactory(Configuration);
            await factory.Start(async ctx =>
            {
                var collection = ctx.GetCollection<JobModel>(JobConstants.CollectionName);
                await collection.InsertOneAsync(ctx.Session, new JobModel()
                {
                    Command = cmd.ToBsonDocument(),
                    CreatedOn = DateTime.Now,
                    Discriminator = GetDiscriminator(cmd),
                    Status = Common.Jobs.JobStatus.Pending,
                    ScheduledForExecution = scheduledOn
                });
            }, IsolationOptions.Committed);
        }

        private string GetDiscriminator(ICommand cmd)
        {
            return cmd.GetType().GetCustomAttribute<JobDiscriminatorAttribute>().Discriminator;
        }
    }
}
