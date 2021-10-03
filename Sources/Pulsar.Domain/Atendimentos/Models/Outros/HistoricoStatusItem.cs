using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class HistoricoStatusItem
    {
        public DateTime Ocorrencia { get; set; }
        public StatusAtendimento? StatusAnterior { get; set; }
        public StatusAtendimento StatusPosterior { get; set; }
    }
}
