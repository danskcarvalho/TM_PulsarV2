using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Common
{
    public class CommandHandler
    {
        protected ContainerFactory ContainerFactory { get; }

        public CommandHandler(ContainerFactory containerFactory)
        {
            ContainerFactory = containerFactory;
        }
    }
}
