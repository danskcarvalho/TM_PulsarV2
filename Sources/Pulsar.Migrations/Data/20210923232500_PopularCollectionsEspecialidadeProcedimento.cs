using Pulsar.Domain.Especialidades.Models;
using Pulsar.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Domain.Procedimentos.Models;
using MongoDB.Driver;

namespace Pulsar.Migrations.Data
{
    [Migration(20210923232500)]
    public class PopularCollectionsEspecialidadeProcedimento : Migration
    {
        public override async Task Up()
        {
            var especialidadesCollection = GetCollection<Especialidade>(Constants.CollectionNames.Especialidades);
            var procedimentosCollection = GetCollection<Procedimento>(Constants.CollectionNames.Procedimentos);

            var linhas = await File.ReadAllLinesAsync(@"Data\Files\especialidades.txt");
            var especialidades = new List<Especialidade>();
            foreach (var item in linhas)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                especialidades.Add(item.FromBson<Especialidade>());
            }

            await especialidadesCollection.DeleteManyAsync(e => true);
            foreach (var list in especialidades.Partition(500))
            {
                await especialidadesCollection.InsertManyAsync(list);
            }

            linhas = await File.ReadAllLinesAsync(@"Data\Files\procedimentos.txt");
            var procedimentos = new List<Procedimento>();
            foreach (var item in linhas)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                procedimentos.Add(item.FromBson<Procedimento>());
            }

            await procedimentosCollection.DeleteManyAsync(e => true);
            foreach (var list in procedimentos.Partition(500))
            {
                await procedimentosCollection.InsertManyAsync(list);
            }
        }
    }
}
