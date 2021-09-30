using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Agendas.Models;
using Pulsar.Domain.Agendas.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class EscalaMongoRepository : MongoRepository<Escala>, IEscalaRepository
    {
        public EscalaMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Escalas;
    }
}
