using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Perfis.Models;
using Pulsar.Domain.Perfis.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class PerfilMongoRepository : MongoRepository<Perfil>, IPerfilRepository
    {
        public PerfilMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Perfis;
    }
}
