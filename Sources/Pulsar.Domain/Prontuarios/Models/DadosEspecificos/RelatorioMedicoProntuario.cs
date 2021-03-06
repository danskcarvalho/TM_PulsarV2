using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuarios.Models
{
    public class RelatorioMedicoProntuario : FragmentoProntuario
    {
        public virtual string Titulo { get; set; }
        public virtual string Texto { get; set; }
        public virtual List<Diagnostico> Diagnosticos { get; set; }
    }
}
