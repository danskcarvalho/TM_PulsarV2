using MongoDB.Driver;
using Pulsar.Common;
using Pulsar.Domain.FilasAtendimentos.Models;
using Pulsar.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Migrations.Schema
{
    [Migration(20211002134000)]
    public class AdicionarIndiceFilaAtendimento : Migration
    {
        public override async Task Up()
        {
            var collection = Database.GetCollection<FilaAtendimentos>(Constants.CollectionNames.FilasAtendimentos);

            var ix_EstabelecimentoId_ProfissionalId_Data = Builders<FilaAtendimentos>.IndexKeys
                .Ascending(j => j.EstabelecimentoId)
                .Ascending(j => j.ProfissionalId)
                .Descending(j => j.Data);
            await collection.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<FilaAtendimentos>(ix_EstabelecimentoId_ProfissionalId_Data, new CreateIndexOptions()
            {
                Name = "ix_EstabelecimentoId_ProfissionalId_Data",
                Unique = true
            }));
        }
    }
}
