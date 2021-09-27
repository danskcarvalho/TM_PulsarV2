using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.PerguntasPuericultura.Models
{
    public class FaixaPuericultura
    {
        public virtual ObjectId FaixaId { get; set; }
        public virtual string Nome { get; set; }
        public virtual int? IdadeMinimaEmDias { get; set; }
        public virtual int? IdadeMaximaEmDias { get; set; }
    }
}
