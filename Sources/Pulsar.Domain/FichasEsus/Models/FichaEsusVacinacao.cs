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
    public class FichaEsusVacinacao : FichaEsus
    {
        public FichaEsusVacinacao()
        {
            FichaTipo = FichaTipo.Vacinacao;
        }

        #region [HeaderTransport]
        public DateTime? DataAtendimento { get; set; }
        public MunicipioResumido Municipio { get; set; }
        public UsuarioResumido Profissional { get; set; }
        public EspecialidadeResumida Especialidade { get; set; }
        public Equipe Equipe { get; set; }
        #endregion

        #region [FichaVacinacaoMaster]
        public List<VVacinacaoPorPaciente> Vacinacoes { get; set; }
        #endregion
    }
}
