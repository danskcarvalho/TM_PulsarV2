using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Global.Models;
using Pulsar.Domain.Global.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class PerguntaPuericulturaMongoRepository : MongoRepository<PerguntaPuericultura>, IPerguntaPuericulturaRepository
    {
        public PerguntaPuericulturaMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.PerguntasPuericultura;
    }
}
