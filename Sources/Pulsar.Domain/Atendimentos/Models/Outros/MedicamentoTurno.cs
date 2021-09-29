using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class MedicamentoTurno
    {
        public Turno Toda { get; set; }
        public int Cada { get; set; }
        public UnidadeTempo CadaUnidadeTempo { get; set; }
    }
}
