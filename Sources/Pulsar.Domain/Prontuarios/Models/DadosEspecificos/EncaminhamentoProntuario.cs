using Pulsar.Common.Enumerations;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuarios.Models
{
    public class EncaminhamentoProntuario : FragmentoProntuario
    {
        public EspecialidadeResumida Especialidade { get; set; }
        public List<DiagnosticoResumido> Diagnosticos { get; set; }
        public string Motivo { get; set; }
        public string DadosClinicos { get; set; }
        public string ResultadoExames { get; set; }
        public string CondutaRealizada { get; set; }
        public string JustificativaPrioridade { get; set; }
        public EncaminhamentoRisco Risco { get; set; }
    }
}
