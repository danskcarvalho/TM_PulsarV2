using MongoDB.Bson;
using Pulsar.Domain.RedesEstabelecimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Estabelecimentos.Models
{
    public class EstabelecimentoResumido
    {
        public ObjectId EstabelecimentoId { get; set; }
        public string Nome { get; set; }
        public string Cnes { get; set; }
        public RedeEstabelecimentosResumida RedeEstabelecimentos { get; set; }
    }
}
