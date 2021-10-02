﻿using Pulsar.Common.Cqrs;
using Pulsar.Contracts.Usuarios.Commands;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Usuarios
{
    public class UsuarioCommandHandler :
        IAsyncCommandHandler<RedefinirSenhaCommand>
    {
        public Task Handle(ICommand cmd, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
