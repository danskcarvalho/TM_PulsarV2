using Pulsar.Common.Enumerations;
using Pulsar.Domain.Especialidades.Models;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.Regioes.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pulsar.Domain.FichasEsus.Models
{
    public class FichaEsusAtendimentoIndividual : FichaEsus
    {
        public FichaEsusAtendimentoIndividual()
        {
            FichaTipo = FichaTipo.AtendimentoIndividual;
        }

        #region [HeaderTransport]
        public DateTime? DataAtendimento { get; set; }
        public MunicipioResumido Municipio { get; set; }
        public UsuarioResumido Profissional { get; set; }
        public EspecialidadeResumida Especialidade { get; set; }
        public Equipe Equipe { get; set; }
        #endregion

        #region [FichaAtendimentoIndividualChildThrift]
        public string NumeroProntuario { get; set; }
        public PacienteResumido Paciente { get; set; }
        public Sexo? PacienteSexo { get; set; }
        public DateTime? PacienteDataNascimento { get; set; }
        public string PacienteCPF { get; set; }
        public string PacienteCNS { get; set; }
        public LocalAtendimento? LocalDeAtendimento { get; set; }
        public Turno? Turno { get; set; }
        public TipoAtendimentoEsus? TipoAtendimento { get; set; }
        public double? PesoAcompanhamentoNutricional { get; set; }
        public double? AlturaAcompanhamentoNutricional { get; set; }
        public AleitamentoMaterno? AleitamentoMaterno { get; set; }
        public DateTime? DumDaGestante { get; set; }
        public int? IdadeGestacional { get; set; }
        public ModalidadeAD AtencaoDomiciliarModalidade { get; set; }
        public AIProblemaCondicaoAvaliacao ProblemaCondicaoAvaliada { get; set; }
        public List<AIExame> Exames { get; set; }
        public bool? VacinaEmDia { get; set; }
        public bool? FicouEmObservacao { get; set; }
        public List<Nasf> Nasfs { get; set; }
        public List<CondutaAtendimentoIndividual> Condutas { get; set; }
        public bool? StGravidezPlanejada { get; set; }
        public int? NuGestasPrevias { get; set; }
        public int? NuPartos { get; set; }
        public RacionalidadeSaude RacionalidadeSaude { get; set; }
        public double? PerimetroCefalico { get; set; }
        public DateTime? DataHoraInicialAtendimento { get; set; }
        public DateTime? DataHoraFinalAtendimento { get; set; }
        #endregion
    }
}
