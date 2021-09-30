using MongoDB.Bson;
using Pulsar.Domain.Servicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.RedesEstabelecimentos.Models
{
    public class Servicos
    {
        public ObjectId? PuerperioId { get; set; }
        public ObjectId? PreNatalId { get; set; }
        public ObjectId? PuericulturaId { get; set; }
        public ObjectId? ConsultaManutencaoOdontologiaServicoId { get; set; }
        public ObjectId? ConsultaRetornoOdontologiaServicoId { get; set; }
        public ObjectId? PrimeiraConsultaOdontologiaServicoId { get; set; }
    }
}
