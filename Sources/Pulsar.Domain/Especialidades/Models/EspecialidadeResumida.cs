using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Especialidades.Models
{
    public class EspecialidadeResumida
    {
        public ObjectId EspecialidadeId { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
}
