﻿using Pulsar.CommandHandlers.Common;
using Pulsar.Common.Database;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Agendamentos
{
    public class AgendamentoCommandHandler : CommandHandler
    {
        public AgendamentoCommandHandler(IDbContextFactory contextfactory, ContainerFactory containerFactory) : base(contextfactory, containerFactory)
        {
        }
    }
}
