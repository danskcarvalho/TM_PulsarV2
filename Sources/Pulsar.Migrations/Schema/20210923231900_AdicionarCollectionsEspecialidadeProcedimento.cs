using Pulsar.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Infrastructure;
using Pulsar.Infrastructure.Database;
using Pulsar.Domain.Procedimentos.Models;
using MongoDB.Driver;
using Pulsar.Domain.Especialidades.Models;

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

            var ix_Procedimentos_TermosPesquisa = Builders<Procedimento>.IndexKeys
                .Text(j => j.TermosPesquisa);
            var ix_Procedimentos_Codigo = Builders<Procedimento>.IndexKeys
                .Ascending(j => j.Codigo);

            var procedimentos = Database.GetCollection<Procedimento>(Constants.CollectionNames.Procedimentos);
            await procedimentos.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<Procedimento>(ix_Procedimentos_TermosPesquisa, new CreateIndexOptions()
            {
                Name = "ix_TermosPesquisa"
            }));
            await procedimentos.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<Procedimento>(ix_Procedimentos_Codigo, new CreateIndexOptions()
            {
                Name = "ix_Codigo"
            }));

            var ix_Especialidades_TermosPesquisa = Builders<Especialidade>.IndexKeys
                .Text(j => j.TermosPesquisa);
            var ix_Especialidades_Codigo = Builders<Especialidade>.IndexKeys
                .Ascending(j => j.Codigo);

            var especialidades = Database.GetCollection<Especialidade>(Constants.CollectionNames.Especialidades);
            await especialidades.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<Especialidade>(ix_Especialidades_TermosPesquisa, new CreateIndexOptions()
            {
                Name = "ix_TermosPesquisa"
            }));
            await especialidades.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<Especialidade>(ix_Especialidades_Codigo, new CreateIndexOptions()
            {
                Name = "ix_Codigo"
            }));

        }
    }
}
