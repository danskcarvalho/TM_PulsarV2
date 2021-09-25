using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Jobs
{
    public enum JobErrorCategory
    {
        Exception = 1,
        ExecutionTimeout = 2,
        PendingTimeout = 3,
        ExecutingTimeout = 4
    }
}
