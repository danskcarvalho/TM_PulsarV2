using Pulsar.Domain.Diagnosticos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuario.Models
{
    public class AntecedentesFamiliaresProntuario : ProntuarioDados
    {
        public AntecedentesGerais Gerais { get; set; }
        public AntecedentesClinicos Clinicos { get; set; }
        public string Observacoes { get; set; }
        public List<DiagnosticoResumido> Diagnosticos { get; set; }
        public class AntecedentesGerais
        {
            public bool? Hepatite { get; set; }
            public bool? Sifilis { get; set; }
            public bool? HIV { get; set; }
            public bool? Tuberculose { get; set; }
            public bool? ProblemasPressao { get; set; }
            public bool? ProblemasCardiacos { get; set; }
            public bool? ProblemasSangramento { get; set; }
            public bool? ProblemasNeurologicos { get; set; }
            public bool? ProblemasRenais { get; set; }
            public bool? ProblemasGastricos { get; set; }
            public bool? ProblemasRespiratorios { get; set; }
            public bool? OutrasDoencas { get; set; }
            public string HepatiteQuem { get; set; }
            public string SifilisQuem { get; set; }
            public string HIVQuem { get; set; }
            public string TuberculoseQuem { get; set; }
            public string ProblemasPressaoQuem { get; set; }
            public string ProblemasCardiacosQuem { get; set; }
            public string ProblemasSangramentoQuem { get; set; }
            public string ProblemasNeurologicosQuem { get; set; }
            public string ProblemasRenaisQuem { get; set; }
            public string ProblemasGastricosQuem { get; set; }
            public string ProblemasRespiratoriosQuem { get; set; }
            public string OutrasDoencasQual { get; set; }
        }
        public class AntecedentesClinicos
        {
            public bool? Hipertensao { get; set; }
            public bool? DiabetesInsulino { get; set; }
            public bool? DiabetesNaoInsulino { get; set; }
            public bool? IAM { get; set; }
            public bool? AVC { get; set; }
        }
    }
}
