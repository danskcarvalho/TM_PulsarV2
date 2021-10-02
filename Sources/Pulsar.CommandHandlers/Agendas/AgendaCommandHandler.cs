using Pulsar.CommandHandlers.Common;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Agendas
{
    public class AgendaCommandHandler : CommandHandler
    {
        public AgendaCommandHandler(ContainerFactory containerFactory) : base(containerFactory)
        {
        }
    }
}
