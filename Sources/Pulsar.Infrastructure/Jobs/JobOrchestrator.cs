using Microsoft.Extensions.Configuration;
using Pulsar.Common.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Jobs
{
    public class JobOrchestrator
    {
        private IConfiguration Configuration { get; }
        public ICommandBus CommandBus { get; }

        public JobOrchestrator(IConfiguration configuration, ICommandBus commandBus)
        {
            this.Configuration = configuration;
            this.CommandBus = commandBus;
        }

        public async Task Run(CancellationToken ct)
        {
            var producer = new JobProducer(Configuration);
            var consumers = new List<JobConsumer>();
            for (int i = 0; i < JobConstants.MaxConsumers; i++)
            {
                consumers.Add(new JobConsumer(Configuration, producer, CommandBus));
            }

            List<Task> tasks = new List<Task>();
            tasks.Add(producer.Run(ct));
            foreach (var c in consumers)
            {
                tasks.Add(c.Run(ct));
            }
            await Task.WhenAll(tasks);
        }
    }
}
