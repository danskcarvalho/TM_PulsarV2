using Pulsar.Common.Cqrs;
using Pulsar.Contracts.Usuarios.Requests;
using Pulsar.Contracts.Usuarios.Results;
using Pulsar.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.RequestHandlers
{
    public class UsuarioRequestHandler : MongoWorker,
        IAsyncRequestHandler<LoginUsuarioRequest, LoginUsuarioResult>
    {
        public UsuarioRequestHandler(MongoContextFactory factory) : base(factory)
        {
        }

        public async Task<LoginUsuarioResult> Handle(LoginUsuarioRequest req, CancellationToken ct)
        {
            return new LoginUsuarioResult() { };
        }
    }
}
