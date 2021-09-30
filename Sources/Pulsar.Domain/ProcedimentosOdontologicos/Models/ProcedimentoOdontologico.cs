using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Comum;
using Pulsar.Domain.Dentes.Models;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.Procedimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.ProcedimentosOdontologicos.Models
{
    public class ProcedimentoOdontologico
    {
        public ObjectId Id { get; set; }
        public LocalProcedimentoOdontologico Local { get; set; }
        public DenteResumido Dente { get; set; }
        public HashSet<Sextante> Sextantes { get; set; }
        public HashSet<Arcada> Arcadas { get; set; }
        public string OutroLocal { get; set; }
        public ProcedimentoResumido Procedimento { get; set; }
        public ObjectId AtendimentoGeradorId { get; set; }
        public string Observacoes { get; set; }
        public FinalizacaoProcedimentoOdontologico Finalizacao { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
