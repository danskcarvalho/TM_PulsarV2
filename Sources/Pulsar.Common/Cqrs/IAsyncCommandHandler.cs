using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Common.Cqrs
{
    public interface IAsyncCommandHandler<TCommand>
        where TCommand : class, ICommand
    {
        Task Handle(TCommand cmd, CancellationToken ct);
    }
}
