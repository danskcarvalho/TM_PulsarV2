using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.RedesEstabelecimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Importacoes.Models
{
    public class ImportacaoCnes : Importacao
    {
        public ImportacaoCnes()
        {
            Tipo = ImportacaoTipo.Cnes;
        }
        public ObjectId RedeEstabelecimentosId { get; set; }
        public string UrlArquivoXml { get; set; }
        public DateTime MesAno { get; set; }
        public ObjectId JobId { get; set; }
    }
}
