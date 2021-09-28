using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Comum;
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
        public RedeEstabelecimentosResumida Rede { get; set; }
        public EstabelecimentoResumido Estabelecimento { get; set; }
        public CriacaoAtualizacao CriacaoAtualizacao { get; set; }
    }
}
