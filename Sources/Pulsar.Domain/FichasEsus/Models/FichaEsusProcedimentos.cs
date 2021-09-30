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
    public class FichaEsusProcedimentos : FichaEsus
    {
        public FichaEsusProcedimentos()
        {
            FichaTipo = FichaTipo.Procedimentos;
        }

        #region [HeaderTransport]
        public DateTime? DataAtendimento { get; set; }
        public MunicipioResumido Municipio { get; set; }
        public UsuarioResumido Profissional { get; set; }
        public EspecialidadeResumida Especialidade { get; set; }
        public Equipe Equipe { get; set; }
        #endregion

        #region [FichaProcedimentoMaster]
        public List<PProcedimentoPorPaciente> AtendProcedimentos { get; set; }

        public long? NumTotalAfericaoPa { get; set; }

        public long? NumTotalGlicemiaCapilar { get; set; }

        public long? NumTotalAfericaoTemperatura { get; set; }

        public long? NumTotalMedicaoAltura { get; set; }

        public long? NumTotalCurativoSimples { get; set; }

        public long? NumTotalMedicaoPeso { get; set; }

        public long? NumTotalColetaMaterialParaExameLaboratorial { get; set; }
        #endregion
    }
}
