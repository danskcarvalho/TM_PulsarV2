using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Agendamentos.Models
{
    public class Cancelamento
    {
        public ObjectId CanceladoPorId { get; set; }
        public DateTime CanceladoEm { get; set; }
        public MotivoCancelamento Motivo { get; set; }
        public string Observacoes { get; set; }
    }
}
