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
        public ObjectId? AtendimentoId { get; set; }
        public ObjectId? Agendamento { get; set; }
        public ObjectId? Paciente { get; set; }
        public TipoAtendimento? TipoAtendimento { get; set; }
        public DateTime? DataInicioEspera { get; set; }
        public RiscoAtendimento? Risco { get; set; }
        public AcoesFilaAtendimentos Pode { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
