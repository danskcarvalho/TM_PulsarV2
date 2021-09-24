using Pulsar.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;

namespace Pulsar.Migrations.Schema
{
    [Migration(20210923231900)]
    public class AdicionarCollectionsEspecialidadeProcedimento : Migration
    {
        public override async Task Up()
        {
            if (!(await Database.CollectionExists(Constants.CollectionNames.Procedimentos)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Procedimentos);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Especialidades)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Especialidades);

        }
    }
}
