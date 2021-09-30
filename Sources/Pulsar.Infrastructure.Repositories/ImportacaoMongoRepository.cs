using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Importacoes.Models;
using Pulsar.Domain.Importacoes.Repositories;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Infrastructure.Repositories
{
    public class ImportacaoMongoRepository : MongoRepository<Importacao>, IImportacaoRepository
    {
        public ImportacaoMongoRepository(MongoContext ctx) : base(ctx)
        {
        }

        protected override string CollectionName => Constants.CollectionNames.Importacoes;
    }
}
