using Pulsar.CommandHandlers.Common;
using Pulsar.Common.Cqrs;
using Pulsar.Common.Database;
using Pulsar.Contracts.Acompanhamentos.Commands;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Acompanhamentos
{
    public class AcompanhamentoCommandHandler : CommandHandler,
        IAsyncCommandHandler<CancelarAcompanhamentoCommand>
    {
        public AcompanhamentoCommandHandler(IDbContextFactory contextfactory, ContainerFactory containerFactory) : base(contextfactory, containerFactory)
        {
        }

        public Task Handle(CancelarAcompanhamentoCommand cmd, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
