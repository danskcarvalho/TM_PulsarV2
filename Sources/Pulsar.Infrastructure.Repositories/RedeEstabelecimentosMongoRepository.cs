using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.RedesEstabelecimentos.Models;
using Pulsar.Domain.RedesEstabelecimentos.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class RedeEstabelecimentosMongoRepository : MongoRepository<RedeEstabelecimentos>, IRedeEstabelecimentosRepository
    {
        public RedeEstabelecimentosMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.RedesEstabelecimentos;
    }
}
