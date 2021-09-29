using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.RedesEstabelecimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Exportacoes.Models
{
    public class ExportacaoEsus : Exportacao
    {
        public ExportacaoEsus()
        {
            Tipo = ExportacaoTipo.Esus;
        }
        public RedeEstabelecimentosResumida RedeEstabelecimentos { get; set; }
        public RemetenteEsus RemetenteEsus { get; set; }
        public long NumeroLote { get; set; }
        public string UrlArquivoExportado { get; set; }
        public ObjectId JobId { get; set; }
    }
}
