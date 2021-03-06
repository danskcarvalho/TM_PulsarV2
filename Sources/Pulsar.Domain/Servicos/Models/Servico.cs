using MongoDB.Bson;
using Pulsar.Domain.Common;
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
        public ObjectId RedeEstabelecimentosId { get; set; }
        public Restricoes Restricoes { get; set; }
        public List<ServicoTipoAtendimento> TiposAtendimentos { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }

    }
}
