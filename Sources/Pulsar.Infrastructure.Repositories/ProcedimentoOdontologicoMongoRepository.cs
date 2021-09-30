using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.ProcedimentosOdontologicos.Models;
using Pulsar.Domain.ProcedimentosOdontologicos.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class ProcedimentoOdontologicoMongoRepository : MongoRepository<ProcedimentoOdontologico>, IProcedimentoOdontologicoRepository
    {
        public ProcedimentoOdontologicoMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.ProcedimentosOdontologicos;
    }
}
