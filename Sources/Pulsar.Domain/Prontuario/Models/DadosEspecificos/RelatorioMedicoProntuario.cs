using Pulsar.Domain.Diagnosticos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuario.Models
{
    public class RelatorioMedicoProntuario : ProntuarioDados
    {
        public virtual string Titulo { get; set; }
        public virtual string Texto { get; set; }
        public virtual List<Diagnostico> Diagnosticos { get; set; }
    }
}
