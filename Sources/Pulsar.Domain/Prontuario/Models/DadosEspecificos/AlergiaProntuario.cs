using Pulsar.Common.Enumerations;
using Pulsar.Domain.Materiais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuario.Models
{
    public class AlergiaProntuario : ProntuarioDados
    {
        public virtual CategoriaAlergia Categoria { get; set; }
        public virtual PrincipioAtivoResumido PrincipioAtivo { get; set; }
        public virtual string SubstanciaNome { get; set; }
        public virtual string Manifestacoes { get; set; }
        public virtual DateTime? DataInstalacao { get; set; }
        public virtual CriticidadeAlergia Criticidade { get; set; }
    }
}
