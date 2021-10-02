using Pulsar.CommandHandlers.Common;
using Pulsar.Common.Cqrs;
using Pulsar.Common.Database;
using Pulsar.Contracts.Atendimentos.Commands;
using Pulsar.Domain.Atendimentos.Services;
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
        private readonly CriarAtendimentoService CriarAtendimentoService = null;
        public AtendimentoCommandHandler(
            CriarAtendimentoService criarAtendimentoService,
            IDbContextFactory contextfactory,
            ContainerFactory containerFactory) : base(contextfactory, containerFactory)
        {
            this.CriarAtendimentoService = criarAtendimentoService;
        }

        public async Task Handle(CriarAtendimentoCommand cmd, CancellationToken ct)
        {
            await ContextFactory.Start(async ctx =>
            {
                await CriarAtendimentoService.Criar(cmd, ContainerFactory.Create(ctx));
            }, IsolationOptions.Committed.WithTransaction());
        }
    }
}
