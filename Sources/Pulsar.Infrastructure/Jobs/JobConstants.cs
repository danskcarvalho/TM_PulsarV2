using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Jobs
{
    public static class JobConstants
    {
        public const string CollectionName = "_Jobs";
        public const int ExecutionTimeout = 3600000; //1 hora
        public const int MaxJobs = 100000;
        public const int ExecutingTimeout = 10800000; //3 horas
        public const int PollingTimeout = 300000; //5 minutos
        public const int PendingTimeout = 86400000; //24 horas
        public const int MaxConsumers = 5;
    }
}
