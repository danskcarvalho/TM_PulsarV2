using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.FichasEsus.Models
{
    public class FichaEsusResumida
    {
        public ObjectId Id { get; set; }
        public string IdentificadorFicha { get; set; }
        public FichaTipo FichaTipo { get; set; }
        public DateTime? DataReferencia { get; set; }
        public ObjectId? Atendimento { get; set; }
    }
}
