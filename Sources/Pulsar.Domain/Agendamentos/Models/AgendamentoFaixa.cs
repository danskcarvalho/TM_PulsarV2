using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Agendamentos.Models
{
    public class AgendamentoFaixa
    {
        public TimeSpan Horario { get; set; }
        public TimeSpan Duracao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}
