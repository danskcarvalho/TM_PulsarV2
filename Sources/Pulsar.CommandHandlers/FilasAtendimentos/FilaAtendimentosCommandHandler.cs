using Pulsar.CommandHandlers.Common;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.FilasAtendimentos
{
    public class FilaAtendimentosCommandHandler : CommandHandler
    {
        public FilaAtendimentosCommandHandler(ContainerFactory containerFactory) : base(containerFactory)
        {
        }
    }
}
