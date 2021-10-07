using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.FilasAtendimentos.Models;
using Pulsar.Domain.FilasAtendimentos.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class FilaAtendimentosMongoRepository : MongoRepository<ItemFilaAtendimentos>, IPacienteEnfileiradoRepository
    {
        public FilaAtendimentosMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.FilasAtendimentos;
    }
}
