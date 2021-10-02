using Pulsar.Common.Database;
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
        protected IDbContextFactory ContextFactory { get; set; }

        public CommandHandler(IDbContextFactory contextfactory, ContainerFactory containerFactory)
        {
            ContainerFactory = containerFactory;
            ContextFactory = contextfactory;
        }
    }
}
