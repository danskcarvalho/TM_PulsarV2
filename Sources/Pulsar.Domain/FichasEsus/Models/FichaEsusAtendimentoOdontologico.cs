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
    public class FichaEsusAtendimentoOdontologico : FichaEsus
    {
        public FichaEsusAtendimentoOdontologico()
        {
            FichaTipo = FichaTipo.Odontologico;
        }

        #region [HeaderTransport]
        public DateTime? DataAtendimento { get; set; }
        public MunicipioResumido Municipio { get; set; }
        public UsuarioResumido Profissional { get; set; }
        public EspecialidadeResumida Especialidade { get; set; }
        public Equipe Equipe { get; set; }
        #endregion

        #region [FichaAtendimentoOdontologicoChild]
        public Paciente Paciente { get; set; }
        public Sexo? PacienteSexo { get; set; }
        public DateTime? PacienteDataNascimento { get; set; }
        public string PacienteCPF { get; set; }
        public string PacienteCNS { get; set; }
        public string NumeroProntuario { get; set; }
        public bool? Gestante { get; set; }
        public bool? NecessidadesEspeciais { get; set; }
        public LocalAtendimento LocalAtendimento { get; set; }
        public TipoAtendimentoEsus? TipoAtendimento { get; set; }
        public List<CondutaAtendimentoOdontologico> TiposEncamOdonto { get; set; }
        public List<FornecimentoOdonto> TiposFornecimOdonto { get; set; }
        public List<VigilanciaSaudeBucal> TiposVigilanciaSaudeBucal { get; set; }
        public List<TipoConsultaOdonto> TiposConsultaOdonto { get; set; }
        public List<AOProcedimentoQuantidade> ProcedimentosRealizados { get; set; }
        public Turno Turno { get; set; }
        public DateTime? DataHoraInicialAtendimento { get; set; }
        public DateTime? DataHoraFinalAtendimento { get; set; }
        #endregion
    }
}
