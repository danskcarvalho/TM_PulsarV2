using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Agendamentos.Models
{
    public class AgendamentoVacinacao
    {
        public MaterialResumido Vacina { get; set; }
        public DoseVacinacao Dose { get; set; }
    }
}
