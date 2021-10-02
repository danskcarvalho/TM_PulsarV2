using Pulsar.Common;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Estabelecimentos.Repositories;
using Pulsar.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Repositories
{
    public class EquipeMongoRepository : MongoRepository<Equipe>, IEquipeRepository
    {
        public EquipeMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Equipes;
    }
}
