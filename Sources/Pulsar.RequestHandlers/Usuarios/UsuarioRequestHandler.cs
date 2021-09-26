using Pulsar.Common.Cqrs;
using Pulsar.Contracts.Requests.Usuarios;
using Pulsar.Contracts.Results.Usuarios;
using Pulsar.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.RequestHandlers.Usuarios
{
    public class UsuarioRequestHandler : MongoWorker,
        IAsyncRequestHandler<LoginUsuarioRequest, LoginUsuarioResult>
    {
        public UsuarioRequestHandler(MongoContextFactory factory) : base(factory)
        {
        }

        public Task<LoginUsuarioResult> Handle(LoginUsuarioRequest req, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
