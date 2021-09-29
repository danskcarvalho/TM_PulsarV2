using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class HistoricoStatus
    {
        public List<HistoricoStatusItem> MudancasStatus { get; set; }
        public DateTime? PrimeiraAbertura { get; set; }
        public DateTime? UltimaFinalizacao { get; set; }
        public DateTime? UltimaInterrupcao { get; set; }
        public DateTime? UltimaRetomada { get; set; }
    }
}
