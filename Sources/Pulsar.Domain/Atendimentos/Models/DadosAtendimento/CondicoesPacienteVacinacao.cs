using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class CondicoesPacienteVacinacao
    {
        public bool? Viajante { get; set; }
        public bool? ComunicanteHanseniase { get; set; }
        public bool? Gestante { get; set; }
        public bool? Puerpera { get; set; }
    }
}
