using Pulsar.CommandHandlers.Common;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Prontuarios
{
    public class ProntuarioCommandHandler : CommandHandler
    {
        public ProntuarioCommandHandler(ContainerFactory containerFactory) : base(containerFactory)
        {
        }
    }
}
