using Pulsar.CommandHandlers.Common;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Pastas
{
    public class PastaCommandHandler : CommandHandler
    {
        public PastaCommandHandler(ContainerFactory containerFactory) : base(containerFactory)
        {
        }
    }
}
