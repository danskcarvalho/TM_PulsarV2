using MongoDB.Bson;
using Pulsar.Domain.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Agendas.Models
{
    public class EscalaConfiguracao
    {
        public ObjectId ConfiguracaoId { get; set; }
        public string Descricao { get; set; }
        public TimeSpan DuracaoSlot { get; set; }
        public bool AgendamentosMultiplos { get; set; }
        public List<EscalaConfiguracaoFaixa> Faixas { get; set; }
    }
}
