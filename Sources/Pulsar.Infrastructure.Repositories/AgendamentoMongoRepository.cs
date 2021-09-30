using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Agendamentos.Models;
using Pulsar.Domain.Agendamentos.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class AgendamentoMongoRepository : MongoRepository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Agendamentos;
    }
}
