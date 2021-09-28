using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Calendarios.Models
{
    public class CalendarioResumido
    {
        public ObjectId CalendarioId { get; set; }
        public string Nome { get; set; }
    }
}
