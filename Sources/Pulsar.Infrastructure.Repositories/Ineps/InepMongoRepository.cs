using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Ineps.Models;
using Pulsar.Domain.Ineps.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories.Ineps
{
    public class InepMongoRepository : MongoRepository<Inep>, IInepRepository
    {
        public InepMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Ineps;
    }
}
