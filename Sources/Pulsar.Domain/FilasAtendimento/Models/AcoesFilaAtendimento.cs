using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.FilasAtendimento.Models
{
    public class AcoesFilaAtendimento
    {
        public bool Iniciar { get; set; }
        public bool Retomar { get; set; }
        public bool Evadir { get; set; }
        public bool Continuar { get; set; }
        public bool FinalizarPorDesistencia { get; set; }
        public bool Reabrir { get; set; }
    }
}
