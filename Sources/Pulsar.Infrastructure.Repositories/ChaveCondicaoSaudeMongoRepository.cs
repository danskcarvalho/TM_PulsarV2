using Pulsar.Common;
using Pulsar.Domain.Global.Models;
using Pulsar.Domain.Global.Repositories;
using Pulsar.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Repositories
{
    public class ChaveCondicaoSaudeMongoRepository : MongoRepository<ChaveCondicaoSaude>, IChaveCondicaoSaudeRepository
    {
        public ChaveCondicaoSaudeMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.ChavesCondicaoSaude;
    }
}
