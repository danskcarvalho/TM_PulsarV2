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
        private JobProducer Producer { get; }
        private List<JobConsumer> Consumers { get; }

        public JobOrchestrator(IConfiguration configuration, ICommandBus commandBus)
        {
            this.Producer = new JobProducer(configuration);
            this.Consumers = new List<JobConsumer>();
            for (int i = 0; i < JobConstants.MaxConsumers; i++)
            {
                Consumers.Add(new JobConsumer(configuration, this.Producer, commandBus));
            }
        }

        public async Task Run(CancellationToken ct)
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(Producer.Run(ct));
            foreach (var c in Consumers)
            {
                tasks.Add(c.Run(ct));
            }
            await Task.WhenAll(tasks);
        }
    }
}
