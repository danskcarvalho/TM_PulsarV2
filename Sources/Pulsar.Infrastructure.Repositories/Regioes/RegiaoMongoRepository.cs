using Pulsar.Common;
using Pulsar.Domain.Regioes.Models;
using Pulsar.Domain.Regioes.Repositories;
using Pulsar.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Repositories.Regioes
{
    public class RegiaoMongoRepository : MongoRepository<Regiao>, IRegiaoRepository
    {
        public RegiaoMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Regioes;
    }
}
