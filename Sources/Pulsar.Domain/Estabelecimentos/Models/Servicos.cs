using MongoDB.Bson;
using Pulsar.Domain.Servicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Estabelecimentos.Models
{
    public class Servicos
    {
        public Servicos()
        {
            PuericulturaIds = new List<ObjectId>();
            PreNatalIds = new List<ObjectId>();
            PuericulturaIds = new List<ObjectId>();
        }
        public List<ObjectId> PuerperioIds { get; set; }
        public List<ObjectId> PreNatalIds { get; set; }
        public List<ObjectId> PuericulturaIds { get; set; }
        public ObjectId? ConsultaManutencaoOdontologiaServicoId { get; set; }
        public ObjectId? ConsultaRetornoOdontologiaServicoId { get; set; }
        public ObjectId? PrimeiraConsultaOdontologiaServicoId { get; set; }
    }
}
