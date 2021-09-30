using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Exportacoes.Models;
using Pulsar.Domain.Exportacoes.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class ExportacaoMongoRepository : MongoRepository<Exportacao>, IExportacaoRepository
    {
        public ExportacaoMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Exportacoes;
    }
}
