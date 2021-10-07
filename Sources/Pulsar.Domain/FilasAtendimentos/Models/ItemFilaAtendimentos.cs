using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Common;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.FilasAtendimentos.Models
{
    public class ItemFilaAtendimentos
    {
        public ItemFilaAtendimentos()
        {
        }

        public ItemFilaAtendimentos(ObjectId usuarioId, AtendimentoComProfissional atendimento, DateTime data)
        {
            Id = ObjectId.GenerateNewId();
            Data = data;
            Status = atendimento.Status;
            EstabelecimentoId = atendimento.EstabelecimentoId;
            ProfissionalId = atendimento.ProfissionalId.Value;
            DataRegistro = DataRegistro.CriadoHoje(usuarioId);
            AtendimentoId = atendimento.Id;
            AgendamentoId = atendimento.AgendamentoId;
            PacienteId = atendimento.PacienteId;
            TipoAtendimento = atendimento.Tipo;
            DataInicioEspera = DateTime.Now;
            Pode = new AcoesFilaAtendimentos() { Evadir = true, Iniciar = true, FinalizarPorDesistencia = true };
        }

        public ObjectId Id { get; set; }
        public DateTime Data { get; set; }
        public ObjectId EstabelecimentoId { get; set; }
        public ObjectId ProfissionalId { get; set; }
        public ObjectId? AtendimentoId { get; set; }
        public ObjectId? AgendamentoId { get; set; }
        public ObjectId? PacienteId { get; set; }
        public ObjectId? CorrelacaoId { get; set; }
        public List<ObjectId> ItensCorrelacionados { get; set; }
        public TipoAtendimento? TipoAtendimento { get; set; }
        public DateTime? DataInicioEspera { get; set; }
        public RiscoAtendimento? Risco { get; set; }
        public StatusAtendimento? Status { get; set; }
        public AcoesFilaAtendimentos Pode { get; set; }
        public bool IsRealizacaoProcedimento => TipoAtendimento == Pulsar.Common.Enumerations.TipoAtendimento.RealizacaoProcedimentos;
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }

        public void Atualizar(ObjectId usuarioId, AtendimentoComProfissional atendimento)
        {
            AtendimentoId = atendimento.Id;
            AgendamentoId = atendimento.AgendamentoId;
            DataInicioEspera = atendimento.HistoricoStatus.MudancasStatus.Max(x => x.Ocorrencia);
            Status = atendimento.Status;
            Pode = GetPode(atendimento.Status);
            DataRegistro.AtualizadoEm = DateTime.Now;
            DataRegistro.AtualizadoPorUsuarioId = usuarioId;
            DataVersion++;
        }

        public void AtualizarPode()
        {
            if (Status != null)
                Pode = GetPode(Status.Value);
        }

        private AcoesFilaAtendimentos GetPode(StatusAtendimento status)
        {
            return new AcoesFilaAtendimentos()
            {
                Continuar = status == StatusAtendimento.Aberto,
                Evadir = status != StatusAtendimento.Cancelado && status != StatusAtendimento.Finalizado,
                FinalizarPorDesistencia = status == StatusAtendimento.Aguardando,
                Iniciar = status == StatusAtendimento.Aguardando,
                Reabrir = status == StatusAtendimento.Finalizado,
                Retomar = status == StatusAtendimento.AguardandoRetorno
            };
        }
    }
}
