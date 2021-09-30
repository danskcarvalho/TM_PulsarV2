using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Comum;
using Pulsar.Domain.Dentes.Models;
using Pulsar.Domain.Procedimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.ProcedimentosOdontologicos.Models
{
    public class ProcedimentoOdontologicoResumido
    {
        public ObjectId ProcedimentoOdontologicoId { get; set; }
        public LocalProcedimentoOdontologico Local { get; set; }
        public DenteResumido Dente { get; set; }
        public HashSet<Sextante> Sextantes { get; set; }
        public HashSet<Arcada> Arcadas { get; set; }
        public string OutroLocal { get; set; }
        public ProcedimentoResumido Procedimento { get; set; }
        public AtendimentoResumido AtendimentoGerador { get; set; }
    }
}
