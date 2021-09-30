using Pulsar.Common;
using Pulsar.Domain.Especialidades.Models;
using Pulsar.Domain.Especialidades.Repositories;
using Pulsar.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Pulsar.Domain.Infrastructure.Repositories
{
    public class EspecialidadeMongoRepository : MongoRepository<Especialidade>, IEspecialidadeRepository
    {
        public EspecialidadeMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Especialidades;
    }
}
