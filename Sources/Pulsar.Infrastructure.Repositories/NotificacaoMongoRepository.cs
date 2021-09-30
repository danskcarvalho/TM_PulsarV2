using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Notificacoes.Models;
using Pulsar.Domain.Notificacoes.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class NotificacaoMongoRepository : MongoRepository<Notificacao>, INotificacaoRepository
    {
        public NotificacaoMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Notificacoes;
    }
}
