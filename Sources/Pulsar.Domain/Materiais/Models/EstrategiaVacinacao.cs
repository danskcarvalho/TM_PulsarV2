using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Materiais.Models
{
    public class EstrategiaVacinacao
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public HashSet<int> Doses { get; set; }
    }
}
