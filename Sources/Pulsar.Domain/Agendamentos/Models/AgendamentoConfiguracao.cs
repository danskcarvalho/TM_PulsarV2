using Pulsar.Domain.Agendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Agendamentos.Models
{
    public class AgendamentoConfiguracao
    {
        public EscalaConfiguracaoFaixa Faixa { get; set; }
        public List<int> Slots { get; set; }
    }
}
