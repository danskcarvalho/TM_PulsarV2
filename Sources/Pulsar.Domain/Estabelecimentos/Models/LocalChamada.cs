using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Estabelecimentos.Models
{
    public class LocalChamada
    {
        public ObjectId LocalChamadaId { get; set; }
        public string Nome { get; set; }
    }
}
