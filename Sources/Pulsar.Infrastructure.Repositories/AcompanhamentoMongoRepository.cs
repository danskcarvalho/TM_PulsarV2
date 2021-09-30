using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Acompanhamentos.Models;
using Pulsar.Domain.Acompanhamentos.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class AcompanhamentoMongoRepository : MongoRepository<Acompanhamento>, IAcompanhamentoRepository
    {
        public AcompanhamentoMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Acompanhamentos;
    }
}
