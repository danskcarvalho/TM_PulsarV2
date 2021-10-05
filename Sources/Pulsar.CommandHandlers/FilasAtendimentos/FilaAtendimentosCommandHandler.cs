using Pulsar.CommandHandlers.Common;
using Pulsar.Common.Cqrs;
using Pulsar.Common.Database;
using Pulsar.Contracts.FilasAtendimentos.Commands;
using Pulsar.Domain.Common;
using Pulsar.Domain.FilasAtendimentos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.FilasAtendimentos
{
    public class FilaAtendimentosCommandHandler : CommandHandler,
        IAsyncCommandHandler<IniciarAtendimentoCommand>
    {
        private readonly AbrirAtendimentoService AbrirAtendimentoService = null;
        public FilaAtendimentosCommandHandler(AbrirAtendimentoService abrirAtendimentoService, IDbContextFactory contextfactory, ContainerFactory containerFactory) : base(contextfactory, containerFactory)
        {
            this.AbrirAtendimentoService = abrirAtendimentoService;
        }

        public async Task Handle(IniciarAtendimentoCommand cmd, CancellationToken ct)
        {
            await ContextFactory.Start(async ctx =>
            {
                await AbrirAtendimentoService.Abrir(cmd, ContainerFactory.Create(ctx));
            }, IsolationOptions.Committed.WithTransaction());
        }
    }
}
