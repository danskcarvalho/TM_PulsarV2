using Pulsar.CommandHandlers.Common;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Agendamentos
{
    public class AgendamentoCommandHandler : CommandHandler
    {
        public AgendamentoCommandHandler(ContainerFactory containerFactory) : base(containerFactory)
        {
        }
    }
}
