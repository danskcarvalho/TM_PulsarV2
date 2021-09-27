using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Materiais.Models
{
    public class CalendarioVacinacao
    {
        public int Dose { get; set; }
        public int? IdadeMinimaEmDias { get; set; }
        public int? IdadeMaximaEmDias { get; set; }
        public Sexo? Sexo { get; set; }
        public bool? Gestante { get; set; }
        public int OrdemDose { get; set; }
    }
}
