using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Exportacoes.Models
{
    public class Exportacao
    {
        public ObjectId Id { get; set; }
        public ExportacaoTipo Tipo { get; set; }
        public StatusExportacao Status { get; set; }
        public List<string> Erros { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
