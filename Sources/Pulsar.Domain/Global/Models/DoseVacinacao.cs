using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Global.Models
{
    public class DoseVacinacao
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public HashSet<int> Estrategias { get; set; }
    }
}
