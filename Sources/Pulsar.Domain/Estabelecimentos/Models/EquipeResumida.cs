using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Estabelecimentos.Models
{
    public class EquipeResumida
    {
        public ObjectId EquipeId { get; set; }
        public string Nome { get; set; }
        public string CodigoIne { get; set; }
        public string CodigoArea { get; set; }
    }
}
