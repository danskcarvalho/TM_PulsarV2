using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class MedicamentoFrequencia
    {
        public int QuantasVezes { get; set; }
        public int Cada { get; set; }
        public UnidadeTempo CadaUnidadeTempo { get; set; }
    }
}
