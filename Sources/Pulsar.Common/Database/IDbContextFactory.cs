using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Common.Database
{
    public interface IDbContextFactory
    {
        Task Start(Func<IDbContext, Task> work,
            IsolationOptions? options = null,
            CancellationToken? cancellationToken = null,
            object currentSession = null);

        Task<T> StartWithResponse<T>(Func<IDbContext, Task<T>> work,
            IsolationOptions? options = null,
            CancellationToken? cancellationToken = null,
            object currentSession = null);
    }
}
