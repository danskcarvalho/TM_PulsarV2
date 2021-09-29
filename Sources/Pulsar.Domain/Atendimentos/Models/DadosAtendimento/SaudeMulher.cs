using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class SaudeMulher
    {
        public DateTime? Dum { get; set; }
        public long? CicloMenstrualDuracao { get; set; }
        public long? CicloMenstrualIntervalo { get; set; }
        public bool? Anticoncepcionais { get; set; }
        public string AnticoncepcionaisQuais { get; set; }
        public bool? Dsts { get; set; }
        public string DstsQuais { get; set; }
        public bool Gestante { get; set; }
    }
}
