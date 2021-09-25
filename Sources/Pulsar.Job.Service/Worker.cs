using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pulsar.Infrastructure.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Job.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly JobOrchestrator _jobOrchestrator;

        public Worker(ILogger<Worker> logger, JobOrchestrator jobOrchestrator)
        {
            _logger = logger;
            _jobOrchestrator = jobOrchestrator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _jobOrchestrator.Run(stoppingToken);
        }
    }
}
