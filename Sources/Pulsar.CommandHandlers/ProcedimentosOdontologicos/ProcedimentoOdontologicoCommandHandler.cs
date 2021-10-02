using Pulsar.CommandHandlers.Common;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.ProcedimentosOdontologicos
{
    public class ProcedimentoOdontologicoCommandHandler : CommandHandler
    {
        public ProcedimentoOdontologicoCommandHandler(ContainerFactory containerFactory) : base(containerFactory)
        {
        }
    }
}
