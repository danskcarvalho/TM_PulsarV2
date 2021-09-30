using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.Pacientes.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class PacienteMongoRepository : MongoRepository<Paciente>, IPacienteRepository
    {
        public PacienteMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Pacientes;
    }
}
