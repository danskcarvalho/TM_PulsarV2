using Pulsar.CommandHandlers.Common;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Pacientes
{
    public class PacienteCommandHandler : CommandHandler
    {
        public PacienteCommandHandler(ContainerFactory containerFactory) : base(containerFactory)
        {
        }
    }
}
