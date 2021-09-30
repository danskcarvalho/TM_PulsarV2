using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Comum;
using Pulsar.Domain.Estabelecimentos.Models;
using System;

namespace Pulsar.Domain.FichasEsus.Models
{
    public class FichaEsus
    {
        public ObjectId Id { get; set; }
        public string IdentificadorFicha { get; set; }
        public FichaTipo FichaTipo { get; set; }
        public DateTime? DataReferencia { get; set; }
        public ObjectId EstabelecimentoId { get; set; }
        public ObjectId AtendimentoId { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
