using Pulsar.CommandHandlers.Common;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Importacoes
{
    public class ImportacaoCommandHandler : CommandHandler
    {
        public ImportacaoCommandHandler(ContainerFactory containerFactory) : base(containerFactory)
        {
        }
    }
}
