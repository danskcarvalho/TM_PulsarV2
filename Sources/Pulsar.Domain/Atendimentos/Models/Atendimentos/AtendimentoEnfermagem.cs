using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoEnfermagem : AtendimentoIndividual
    {
        public AtendimentoEnfermagem()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtendimento.Enfermagem;
        }
    }
}
