using Pulsar.Common;
using Pulsar.Common.Database;
using Pulsar.Domain.Procedimentos.Models;
using Pulsar.Domain.Procedimentos.Repositories;
using Pulsar.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Pulsar.Domain.Infrastructure.Repositories.Procedimentos
{
    public class ProcedimentoMongoRepository : MongoRepository<Procedimento>, IProcedimentoRepository
    {
        public ProcedimentoMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Procedimentos;
    }
}
