using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Common.Database
{
    public interface IDbContext
    {
        public object Session { get; }
        public object Client { get; }
        public object Database { get; }
        public CancellationToken CancellationToken { get; }
        public IsolationOptions Options { get; }
    }
}
