using Pulsar.CommandHandlers.Common;
using Pulsar.Common.Cqrs;
using Pulsar.Contracts.Atendimentos.Commands;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Atendimentos
{
    public class AtendimentoCommandHandler : CommandHandler,
        IAsyncCommandHandler<CriarAtendimentoCommand>
    {
        public AtendimentoCommandHandler(ContainerFactory containerFactory) : base(containerFactory)
        {
        }

        public async Task Handle(CriarAtendimentoCommand cmd, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
