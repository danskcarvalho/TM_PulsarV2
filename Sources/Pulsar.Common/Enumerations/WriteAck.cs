using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum WriteAck
    {
        Unacknowledged,
        WMajority,
        W3,
        Acknowledged,
        W2,
        W1
    }
}
