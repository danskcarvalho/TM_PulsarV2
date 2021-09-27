using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Etnias.Models;
using Pulsar.Domain.Etnias.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories.Etnias
{
    public class EtniaMongoRepository : MongoRepository<Etnia>, IEtniaRepository
    {
        public EtniaMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Etnias;
    }
}
