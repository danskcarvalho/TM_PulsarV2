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
        IAsyncCommandHandler<CriarAtendimentoCommand>,
        IAsyncCommandHandler<ReabrirAtendimentoCommand>,
        IAsyncCommandHandler<AcompanharAtendimentoCommand>
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
                await CriarAtendimentoService.Criar(cmd, agendamento: null, ContainerFactory.Create(ctx));
            }, IsolationOptions.Committed.WithTransaction());
        }

        public async Task Handle(ReabrirAtendimentoCommand cmd, CancellationToken ct)
        {
            await ContextFactory.Start(async ctx =>
            {
                var container = ContainerFactory.Create(ctx);
                var usuario = await container.Usuarios.FindOneById(cmd.UsuarioId, noSession: true);
                var estabelecimento = await container.Estabelecimentos.FindOneById(cmd.UsuarioId, noSession: true);
                var atendimento = await container.Atendimentos.FindOneById(cmd.AtendimentoId);
                await atendimento.Reabrir(usuario, estabelecimento, container);
            }, IsolationOptions.Committed.WithTransaction());
        }

        public async Task Handle(AcompanharAtendimentoCommand cmd, CancellationToken ct)
        {
            await ContextFactory.Start(async ctx =>
            {
                var container = ContainerFactory.Create(ctx);
                var usuario = await container.Usuarios.FindOneById(cmd.UsuarioId, noSession: true);
                var estabelecimento = await container.Estabelecimentos.FindOneById(cmd.UsuarioId, noSession: true);
                var atendimento = await container.Atendimentos.FindOneById(cmd.AtendimentoId);
                await atendimento.Acompanhar(usuario, estabelecimento, container);
            }, IsolationOptions.Committed.WithTransaction());
        }
    }
}
