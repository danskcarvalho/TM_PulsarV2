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
            var itemFila = await container.ItensFilaAtendimentos.FindOneById(cmd.ItemId.Value);
            if (itemFila == null || itemFila.EstabelecimentoId != cmd.EstabelecimentoId)
                throw new PulsarException(PulsarErrorCode.BadRequest, "O atendimento já foi iniciado por outro profissional.");
            if (itemFila.ProfissionalId != cmd.UsuarioId)
                throw new PulsarException(PulsarErrorCode.BadRequest, "Apenas o profissional pode iniciar este atendimento.");
            if (itemFila.Status != StatusAtendimento.Aguardando)
                throw new PulsarException(PulsarErrorCode.BadRequest, "O atendimento não pode ser aberto pois já foi iniciado ou finalizado.");

            if (itemFila.AtendimentoId == null && itemFila.AgendamentoId != null)
            {
                var agendamento = await container.Agendamentos.FindOneById(itemFila.AgendamentoId.Value);
               
                var criarAtendimentoCmd = new CriarAtendimentoCommand()
                {
                    UsuarioId = cmd.UsuarioId,
                    Categoria = CategoriaAtendimento.Individual,
                    PacienteAnonimo = null,
                    PacienteId = itemFila.PacienteId,
                    EstabelecimentoId = cmd.EstabelecimentoId,
                    Atendimentos = new List<CriarAtendimentoCommand.AtendimentoModel>()
                    {
                        new CriarAtendimentoCommand.AtendimentoModel()
                        {
                            ProfissionalId = cmd.UsuarioId,
                            ServicoId = agendamento.ServicoId,
                            Tipo = itemFila.TipoAtendimento ?? cmd.TipoAtendimento
                        }
                    }
                };

                await CriarAtendimentoService.Criar(criarAtendimentoCmd, agendamento, container);
                itemFila.AtendimentoId = criarAtendimentoCmd.Atendimentos[0].AtendimentoId.Value;
            }
            else if (itemFila.AtendimentoId == null)
                throw new PulsarException(PulsarErrorCode.Unknown);

            //ensures that atendimentos is in database
            await container.Flush();
            //pega o atendimento
            var atendimento = (await container.Atendimentos.FindOneById(itemFila.AtendimentoId.Value)) as AtendimentoComProfissional;
            //abre o atendimento
            var outrasFilasAtendimentos = atendimento.ItensFilaAtendimentos.Where(id => id != itemFila.Id).ToList();
            await atendimento.Abrir(cmd.UsuarioId, itemFila.Id, container);
            //remove o atendimento de outras filas de atendimentos
            await container.ItensFilaAtendimentos.DeleteMany(ifa => outrasFilasAtendimentos.Contains(ifa.Id));
            //altera o item atual
            itemFila.Atualizar(cmd.UsuarioId, atendimento as AtendimentoComProfissional);
            await container.ItensFilaAtendimentos.UpdateOne(itemFila);
        }
    }
}
