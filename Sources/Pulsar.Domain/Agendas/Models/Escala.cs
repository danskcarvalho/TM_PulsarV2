using MongoDB.Bson;
using Pulsar.Domain.Agendamentos.Models;
using Pulsar.Domain.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Agendas.Models
{
    public class Escala
    {
        public ObjectId Id { get; set; }
        public ObjectId AgendaId { get; set; }
        public EscalaConfiguracao Configuracao { get; set; }
        public DateTime Data { get; set; }
        public List<EscalaSlot> Slots { get; set; }
        public List<ObjectId> OutrosAgendamentos { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
