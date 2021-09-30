using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Estabelecimentos.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class EstabelecimentoMongoRepository : MongoRepository<Estabelecimento>, IEstabelecimentoRepository
    {
        public EstabelecimentoMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Estabelecimentos;
    }
}
