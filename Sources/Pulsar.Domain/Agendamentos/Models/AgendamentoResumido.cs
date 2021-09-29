using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Agendas.Models;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.Servicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Agendamentos.Models
{
    public class AgendamentoResumido
    {
        public ObjectId AgendamentoId { get; set; }
        public AgendaResumida Agenda { get; set; }
        public DateTime Data { get; set; }
        public ServicoResumido Servico { get; set; }
        public AgendamentoFaixa FaixaHorarios { get; set; }
        public EstabelecimentoResumido Estabelecimento { get; set; }
        public PacienteResumido Paciente { get; set; }
        public StatusAgendamento Status { get; set; }
        public bool Extra { get; set; }
    }
}
