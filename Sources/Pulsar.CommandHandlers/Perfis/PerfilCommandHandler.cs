using Pulsar.CommandHandlers.Common;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Perfis
{
    public class PerfilCommandHandler : CommandHandler
    {
        public PerfilCommandHandler(ContainerFactory containerFactory) : base(containerFactory)
        {
        }
    }
}
