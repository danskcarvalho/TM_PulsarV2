using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoMedico : AtendimentoIndividual
    {
        public AtendimentoMedico()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtendimento.Medico;
        }
    }
}
