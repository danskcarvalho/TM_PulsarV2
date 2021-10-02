using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Global.Models
{
    public class MedicamentoUnidadeFornecimento
    {
        public ObjectId UnidadeFornecimentoId { get; set; }
        public string Nome { get; set; }
        public string CodigoEsus { get; set; }
    }
}
