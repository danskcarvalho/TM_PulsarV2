using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Jobs
{
    public enum JobStatus
    {
        Pending = 1,
        Executing = 2,
        Done = 3,
        Error = 4
    }
}
