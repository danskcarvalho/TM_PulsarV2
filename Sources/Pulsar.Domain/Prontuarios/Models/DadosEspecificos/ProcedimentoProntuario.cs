using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuarios.Models
{
    public class ProcedimentoProntuario : FragmentoProntuario
    {
        public bool ApenasReportado { get; set; }
        public ProcedimentoResumido Procedimento { get; set; }
        public List<DiagnosticoResumido> Diagnosticos { get; set; }
        public string Justificativa { get; set; }
    }
}
