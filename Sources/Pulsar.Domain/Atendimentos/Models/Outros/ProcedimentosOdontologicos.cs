using Pulsar.Domain.ProcedimentosOdontologicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class ProcedimentosOdontologicos
    {
        public List<ProcedimentoOdontologicoResumido> Criados { get; set; }
        public List<ProcedimentoOdontologicoResumido> Concluidos { get; set; }
        public List<ProcedimentoOdontologicoResumido> Desfeitos { get; set; }
    }
}
