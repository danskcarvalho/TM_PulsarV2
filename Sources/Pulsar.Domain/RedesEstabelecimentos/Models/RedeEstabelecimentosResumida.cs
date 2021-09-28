using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.RedesEstabelecimentos.Models
{
    public class RedeEstabelecimentosResumida
    {
        public ObjectId RedeEstabelecimentoId { get; set; }
        public string RedeEstabelecimentoNome { get; set; }
    }
}
