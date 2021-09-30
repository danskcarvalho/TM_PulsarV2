using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Usuarios.Models;
using Pulsar.Domain.Usuarios.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class UsuarioMongoRepository : MongoRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Usuarios;
    }
}
