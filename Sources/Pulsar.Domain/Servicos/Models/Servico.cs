using MongoDB.Bson;
using Pulsar.Domain.Comum;
using Pulsar.Domain.RedesEstabelecimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Servicos.Models
{
    public class Servico
    {
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public RedeEstabelecimentosResumida RedeEstabelecimentos { get; set; }
        public Restricoes Restricoes { get; set; }
        public List<ServicoTipoAtendimento> TiposAtendimentos { get; set; }
        public CriacaoAtualizacao CriacaoAtualizacao { get; set; }
        public long DataVersion { get; set; }

    }
}
