﻿using Pulsar.CommandHandlers.Common;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Notificacoes
{
    public class NotificacaoCommandHandler : CommandHandler
    {
        public NotificacaoCommandHandler(ContainerFactory containerFactory) : base(containerFactory)
        {
        }
    }
}
