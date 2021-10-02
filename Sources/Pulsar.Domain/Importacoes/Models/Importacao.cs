using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Importacoes.Models
{
    public class Importacao
    {
        public ObjectId Id { get; set; }
        public ImportacaoTipo Tipo { get; set; }
        public StatusImportacao Status { get; set; }
        public List<string> Erros { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
