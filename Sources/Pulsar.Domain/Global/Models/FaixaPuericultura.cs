using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Global.Models
{
    public class FaixaPuericultura
    {
        public ObjectId FaixaId { get; set; }
        public string Nome { get; set; }
        public int? IdadeMinimaEmDias { get; set; }
        public int? IdadeMaximaEmDias { get; set; }
    }
}
