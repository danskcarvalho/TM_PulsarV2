using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Common.Cqrs
{
    public interface IRequestBus
    {
        Task<TResponse> Request<T, TResponse>(T request, CancellationToken? ct = null) where T : class, IRequest where TResponse : class;
    }
}
