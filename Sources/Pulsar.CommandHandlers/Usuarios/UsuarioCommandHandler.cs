using Pulsar.CommandHandlers.Common;
using Pulsar.Common.Cqrs;
using Pulsar.Common.Database;
using Pulsar.Contracts.Usuarios.Commands;
using Pulsar.Domain.Common;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.CommandHandlers.Usuarios
{
    public class UsuarioCommandHandler : CommandHandler,
        IAsyncCommandHandler<RedefinirSenhaCommand>
    {
        public UsuarioCommandHandler(IDbContextFactory contextfactory, ContainerFactory containerFactory) : base(contextfactory, containerFactory)
        {
        }

        public Task Handle(RedefinirSenhaCommand cmd, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
