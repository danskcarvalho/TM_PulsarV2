using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Agendas.Models
{
    public class AgendaResumida
    {
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
    }
}
