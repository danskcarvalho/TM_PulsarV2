using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Atendimentos.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class AtendimentoMongoRepository : MongoRepository<Atendimento>, IAtendimentoRepository
    {
        public AtendimentoMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Atendimentos;
    }
}
