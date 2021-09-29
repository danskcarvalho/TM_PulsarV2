using MongoDB.Bson;
using Pulsar.Domain.Agendamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Agendas.Models
{
    public class EscalaSlot
    {
        public int SlotId { get; set; }
        public ObjectId FaixaId { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }
        public TimeSpan Duracao { get; set; }
        public Bloqueio Bloqueio { get; set; }
        public List<AgendamentoResumido> Agendamentos { get; set; }
    }
}
