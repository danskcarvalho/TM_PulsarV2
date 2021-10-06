using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Agendamentos.Models;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Common;
using Pulsar.Domain.Pacientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.FilasAtendimentos.Models
{
    public class FilaAtendimentosItem
    {
        public FilaAtendimentosItem()
        {

        }
        public FilaAtendimentosItem(AtendimentoComProfissional atd) : this()
        {
            AtendimentoId = atd.Id;
            AgendamentoId = atd.AgendamentoId;
            PacienteId = atd.PacienteId;
            TipoAtendimento = atd.Tipo;
            DataInicioEspera = DateTime.Now;
            Pode = new AcoesFilaAtendimentos() { Evadir = true, Iniciar = true, FinalizarPorDesistencia = true };
            DataRegistro = DataRegistro.CriadoHoje(atd.DataRegistro.CriadoPorUsuarioId.Value);
            FilasCorrelacionadas = new List<ObjectId>();
            ItemId = ObjectId.GenerateNewId();
            Status = StatusAtendimento.Aguardando;
        }

        public FilaAtendimentosItem(AtendimentoComProfissional atd, ObjectId correlacaoId, IEnumerable<ObjectId> filasCorrelacionadas) : this(atd)
        {
            CorrelacaoId = correlacaoId;
            FilasCorrelacionadas.AddRange(filasCorrelacionadas);
        }

        public ObjectId ItemId { get; set; }
        public ObjectId? AtendimentoId { get; set; }
        public ObjectId? AgendamentoId { get; set; }
        public ObjectId? PacienteId { get; set; }
        public ObjectId? CorrelacaoId { get; set; }
        public List<ObjectId> FilasCorrelacionadas { get; set; }
        public TipoAtendimento? TipoAtendimento { get; set; }
        public DateTime? DataInicioEspera { get; set; }
        public RiscoAtendimento? Risco { get; set; }
        public StatusAtendimento? Status { get; set; }
        public AcoesFilaAtendimentos Pode { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
        public bool IsRealizacaoProcedimento => TipoAtendimento == Pulsar.Common.Enumerations.TipoAtendimento.RealizacaoProcedimentos;

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
