using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Common.Exceptions;
using Pulsar.Common.Services;
using Pulsar.Contracts.Atendimentos.Commands;
using Pulsar.Contracts.FilasAtendimentos.Commands;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Atendimentos.Services;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.FilasAtendimentos.Services
{
    public class AbrirAtendimentoService : IService
    {
        private readonly CriarAtendimentoService CriarAtendimentoService = null;

        public async Task Abrir(IniciarAtendimentoCommand cmd, Container container)
        {
            var filaAtendimentos = await container.FilasAtendimentos.FindOneById(cmd.FilaAtendimentosId.Value);
            if (filaAtendimentos == null || filaAtendimentos.EstabelecimentoId != cmd.EstabelecimentoId)
                throw new PulsarException(PulsarErrorCode.NotFound);
            if (filaAtendimentos.ProfissionalId != cmd.UsuarioId)
                throw new PulsarException(PulsarErrorCode.BadRequest, "Apenas o profissional da fila de atendimentos pode abrir este atendimento.");
            var item = filaAtendimentos.Items.FirstOrDefault(i => i.ItemId == cmd.ItemId);
            if (item == null)
                throw new PulsarException(PulsarErrorCode.BadRequest, "O atendimento já foi iniciado por outro profissional.");
            if (item.AtendimentoId == null && item.AgendamentoId != null)
            {
                var agendamento = await container.Agendamentos.FindOneById(item.AgendamentoId.Value);
                var criarAtendimentoCmd = new CriarAtendimentoCommand()
                {
                    UsuarioId = cmd.UsuarioId,
                    Categoria = CategoriaAtendimento.Individual,
                    PacienteAnonimo = null,
                    PacienteId = item.PacienteId,
                    EstabelecimentoId = cmd.EstabelecimentoId,
                    Atendimentos = new List<CriarAtendimentoCommand.AtendimentoModel>()
                    {
                        new CriarAtendimentoCommand.AtendimentoModel()
                        {
                            ProfissionalId = cmd.UsuarioId,
                            ServicoId = null,
                            Tipo = cmd.TipoAtendimento
                        }
                    }
                };

                await CriarAtendimentoService.Criar(criarAtendimentoCmd, agendamento, container);
                item.AtendimentoId = criarAtendimentoCmd.Atendimentos[0].AtendimentoId.Value;
            }
            else if (item.AtendimentoId == null)
                throw new PulsarException(PulsarErrorCode.Unknown);

            //ensures that atendimentos is in database
            await container.Flush();
            //pega o atendimento
            var atendimento = await container.Atendimentos.FindOneById(item.AtendimentoId.Value);
            //abre o atendimento
            await atendimento.Abrir(cmd.UsuarioId, container);
            //remove o atendimento de outras filas de atendimentos
            await RemoverFilasCorrelacionadas(cmd.UsuarioId, item.CorrelacaoId, item.FilasCorrelacionadas, container);
            //altera o item atual
            item.Atualizar(cmd.UsuarioId, atendimento as AtendimentoComProfissional);
            await container.FilasAtendimentos.UpdateOne(filaAtendimentos);
        }

        private async Task RemoverFilasCorrelacionadas(ObjectId usuarioId, ObjectId? correlacaoId, List<ObjectId> filasCorrelacionadas, Container container)
        {
            if (correlacaoId == null)
                return;
            foreach (var filaId in filasCorrelacionadas)
            {
                var fila = await container.FilasAtendimentos.FindOneById(filaId);
                fila.Items = fila.Items.Where(x => x.CorrelacaoId == correlacaoId).ToList();
                fila.DataRegistro.Atualizado(usuarioId);
                fila.DataVersion++;
                await container.FilasAtendimentos.UpdateOne(fila);
            }
        }
    }
}
