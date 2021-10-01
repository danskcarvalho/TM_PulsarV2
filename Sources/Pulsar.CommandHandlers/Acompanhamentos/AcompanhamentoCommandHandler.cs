using Pulsar.Common.Cqrs;
using Pulsar.Contracts.Acompanhamentos.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers
{
    public class AcompanhamentoCommandHandler :
        IAsyncCommandHandler<CancelarAcompanhamentoCommand>
    {
        public Task Handle(ICommand cmd, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
