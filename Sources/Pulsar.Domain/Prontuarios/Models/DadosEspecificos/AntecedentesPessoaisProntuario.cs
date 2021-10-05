using Pulsar.Common.Enumerations;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuarios.Models
{
    public class AntecedentesPessoaisProntuario : FragmentoProntuario
    {
        public AntecedentesGerais Gerais { get; set; }
        public AntecedentesClinicos Clinicos { get; set; }
        public AntecedentesAoNascer AoNascer { get; set; }
        public AntecedentesGestacionais Gestacionais { get; set; }
        public AntecedentesSaudeMulher SaudeMulher { get; set; }
        public string Observacoes { get; set; }
        public List<DiagnosticoResumido> Diagnosticos { get; set; }
        public List<DiagnosticoResumido> DiagnosticosObstetricos { get; set; }

        public class AntecedentesAoNascer
        {
            public TipoGravidez? TipoGravidezMaterna { get; set; }
            public TipoParto? TipoPartoMaterno { get; set; }
            public int? ApgarMaterno1Min { get; set; }
            public int? ApgarMaterno5Min { get; set; }
            public int? ApgarMaterno10Min { get; set; }
            public int? IdadeGestacionalMaternaEmDias { get; set; }
            public decimal? Peso { get; set; }
            public decimal? Comprimento { get; set; }
            public decimal? PerimetroCefalico { get; set; }
        }
        public class AntecedentesGestacionais
        {
            public int? GestacoesPrevias { get; set; }
            public int? Abortos { get; set; }
            public int? Partos { get; set; }
            public int? PartosVaginais { get; set; }
            public int? PartosDomiciliares { get; set; }
            public int? Cesareas { get; set; }
            public int? NascidosVivos { get; set; }
            public int? Vivem { get; set; }
            public int? NascidosMortos { get; set; }
            public int? RN2500g { get; set; }
            public int? RN4500g { get; set; }
            public int? Mortos1Sem { get; set; }
            public int? MortosDepois1Sem { get; set; }
            public bool? DesfechoGestacaoMenos1Ano { get; set; }
            public bool? DHEG { get; set; }
            public bool? DiabetesGestacional { get; set; }
            public int? IdadePrimeiraGestacao { get; set; }
            public int? NumGravidezesEctopicas { get; set; }
            public int? NumPreEclampsias { get; set; }
            public int? NumEclampsias { get; set; }
            public DateTime? DataDesfechoUltimaGestacao { get; set; }
        }
        public class AntecedentesSaudeMulher
        {
            public long? CicloMenstrualDuracao { get; set; }
            public long? CicloMenstrualIntervalo { get; set; }
            public bool? Anticoncepcionais { get; set; }
            public string AnticoncepcionaisQuais { get; set; }
        }
        public class AntecedentesGerais
        {
            public bool? Infertilidade { get; set; }
            public bool? FazendoTratamentoMedico { get; set; }
            public bool? TomandoMedicacao { get; set; }
            public bool? TomouAnestesiaDental { get; set; }
            public bool? UsouPenicilina { get; set; }
            public bool? Desmaio { get; set; }
            public bool? Tabaco { get; set; }
            public bool? Alcool { get; set; }
            public bool? OutrasDrogas { get; set; }
            public string TratamentoMedicoQual { get; set; }
            public string TomandoQualMedicacao { get; set; }
            public string AnestesiaDentalReacao { get; set; }
            public string PenicilinaReacao { get; set; }
            public string OutrasDrogasQual { get; set; }
            public bool? DSTs { get; set; }
            public string DSTsQuais { get; set; }
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
