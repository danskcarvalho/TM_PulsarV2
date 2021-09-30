using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Familias.Models;
using Pulsar.Domain.Familias.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class FamiliaMongoRepository : MongoRepository<Familia>, IFamiliaRepository
    {
        public FamiliaMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Familias;
    }
}
