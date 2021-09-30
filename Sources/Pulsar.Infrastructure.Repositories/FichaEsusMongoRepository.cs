using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.FichasEsus.Models;
using Pulsar.Domain.FichasEsus.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class FichaEsusMongoRepository : MongoRepository<FichaEsus>, IFichaEsusRepository
    {
        public FichaEsusMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.FichasEsus;
    }
}
