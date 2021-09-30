using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Prontuarios.Models;
using Pulsar.Domain.Prontuarios.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class ProntuarioMongoRepository : MongoRepository<Prontuario>, IProntuarioRepository
    {
        public ProntuarioMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Prontuarios;
    }
}
