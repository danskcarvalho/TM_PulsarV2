using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Common;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.RedesEstabelecimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Perfis.Models
{
    public class Perfil
    {
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public HashSet<Permissao> Permissoes { get; set; }
        public ObjectId? RedeId { get; set; }
        public ObjectId? EstabelecimentoId { get; set; }
        public DataRegistro DataRegistro { get; set; }
    }
}
