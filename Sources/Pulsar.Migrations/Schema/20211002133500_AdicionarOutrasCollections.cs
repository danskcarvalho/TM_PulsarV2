using Pulsar.Common;
using Pulsar.Infrastructure.Database;
using Pulsar.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Migrations.Schema
{
    [Migration(20211002133500)]
    public class AdicionarOutrasCollections : Migration
    {
        public override async Task Up()
        {
            if (!(await Database.CollectionExists(Constants.CollectionNames.Acompanhamentos)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Acompanhamentos);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Agendamentos)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Agendamentos);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Agendas)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Agendas);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Atendimentos)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Atendimentos);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Escalas)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Escalas);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Estabelecimentos)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Estabelecimentos);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Exportacoes)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Exportacoes);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Familias)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Familias);

            if (!(await Database.CollectionExists(Constants.CollectionNames.FichasEsus)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.FichasEsus);

            if (!(await Database.CollectionExists(Constants.CollectionNames.FilasAtendimentos)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.FilasAtendimentos);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Importacoes)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Importacoes);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Notificacoes)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Notificacoes);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Pacientes)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Pacientes);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Pastas)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Pastas);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Perfis)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Perfis);

            if (!(await Database.CollectionExists(Constants.CollectionNames.ProcedimentosOdontologicos)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.ProcedimentosOdontologicos);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Prontuarios)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Prontuarios);

            if (!(await Database.CollectionExists(Constants.CollectionNames.RedesEstabelecimentos)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.RedesEstabelecimentos);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Servicos)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Servicos);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Usuarios)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Usuarios);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Equipes)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Equipes);
        }
    }
}
