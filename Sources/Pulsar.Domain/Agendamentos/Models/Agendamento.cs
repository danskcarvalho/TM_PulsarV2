using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Agendas.Models;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Common;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.RedesEstabelecimentos.Models;
using Pulsar.Domain.Servicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Agendamentos.Models
{
    public class Agendamento
    {
        public ObjectId Id { get; set; }
        public ObjectId AgendaId { get; set; }
        public DateTime Data { get; set; }
        public ObjectId ServicoId { get; set; }
        public AgendamentoFaixa FaixaHorarios { get; set; }
        public AgendamentoFaixa FaixaHorariosRequisitada { get; set; }
        public AgendamentoConfiguracao Configuracao { get; set; }
        public ObjectId EstabelecimentoId { get; set; }
        public ObjectId? AtendimentoGeradoId { get; set; }
        public ObjectId Paciente { get; set; }
        public Cancelamento Cancelamento { get; set; }
        public StatusAgendamento Status { get; set; }
        public bool Extra { get; set; }
        public DateTime? Chegada { get; set; }
        public List<AgendamentoVacinacao> Aprazamentos { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public string Observacoes { get; set; }
        public long DataVersion { get; set; }
    }
}
