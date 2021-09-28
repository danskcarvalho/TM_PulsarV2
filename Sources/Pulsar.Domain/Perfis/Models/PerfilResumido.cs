using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Perfis.Models
{
    public class PerfilResumido
    {
        public ObjectId PerfilId { get; set; }
        public string Nome { get; set; }
    }
}
