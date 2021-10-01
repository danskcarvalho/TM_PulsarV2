using MongoDB.Driver;
using Pulsar.Common;
using Pulsar.Domain.ChavesCondicaoSaude.Models;
using Pulsar.Domain.Diagnosticos.Models;
using Pulsar.Domain.Etnias.Models;
using Pulsar.Domain.Ineps.Models;
using Pulsar.Domain.Materiais.Models;
using Pulsar.Domain.PrincipiosAtivos.Models;
using Pulsar.Domain.Regioes.Models;
using Pulsar.Infrastructure.Database;
using Pulsar.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Migrations.Schema
{
    [Migration(20210927172600)]
    public class AdicionarCollectionsFixas : Migration
    {
        public override async Task Up()
        {
            if (!(await Database.CollectionExists(Constants.CollectionNames.ChavesCondicaoSaude)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.ChavesCondicaoSaude);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Dentes)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Dentes);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Diagnosticos)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Diagnosticos);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Etnias)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Etnias);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Ineps)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Ineps);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Materiais)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Materiais);

            if (!(await Database.CollectionExists(Constants.CollectionNames.PerguntasPuericultura)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.PerguntasPuericultura);

            if (!(await Database.CollectionExists(Constants.CollectionNames.Regioes)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Regioes);

            if (!(await Database.CollectionExists(Constants.CollectionNames.PrincipiosAtivos)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.PrincipiosAtivos);

            //criar índices
            //chaves de condição de saúde
            var ix_ChavesCondicaoSaude_TermosPesquisa = Builders<ChaveCondicaoSaude>.IndexKeys
                .Text(j => j.TermosPesquisa);

            var chavesCondicaoSaude = Database.GetCollection<ChaveCondicaoSaude>(Constants.CollectionNames.ChavesCondicaoSaude);
            await chavesCondicaoSaude.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<ChaveCondicaoSaude>(ix_ChavesCondicaoSaude_TermosPesquisa, new CreateIndexOptions()
            {
                Name = "ix_TermosPesquisa"
            }));

            //diagnosticos
            var ix_Diagnosticos_Tipo_TermosPesquisa = Builders<Diagnostico>.IndexKeys
                .Ascending(j => j.Tipo)
                .Text(j => j.TermosPesquisa);

            var ix_Diagnosticos_Tipo_Codigo = Builders<Diagnostico>.IndexKeys
                .Ascending(j => j.Tipo)
                .Ascending(j => j.Codigo);

            var diagnosticos = Database.GetCollection<Diagnostico>(Constants.CollectionNames.Diagnosticos);
            await diagnosticos.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<Diagnostico>(ix_Diagnosticos_Tipo_TermosPesquisa, new CreateIndexOptions()
            {
                Name = "ix_Tipo_TermosPesquisa"
            }));
            await diagnosticos.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<Diagnostico>(ix_Diagnosticos_Tipo_Codigo, new CreateIndexOptions()
            {
                Name = "ix_Tipo_Codigo"
            }));

            //etnias
            var ix_Etnias_TermosPesquisa = Builders<Etnia>.IndexKeys
                .Text(j => j.TermosPesquisa);

            var etnias = Database.GetCollection<Etnia>(Constants.CollectionNames.Etnias);
            await etnias.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<Etnia>(ix_Etnias_TermosPesquisa, new CreateIndexOptions()
            {
                Name = "ix_TermosPesquisa"
            }));

            //ineps
            var ix_Ineps_TermosPesquisa = Builders<Inep>.IndexKeys
                .Text(j => j.TermosPesquisa);

            var ix_Ineps_Codigo = Builders<Inep>.IndexKeys
                .Ascending(j => j.Codigo);

            var ineps = Database.GetCollection<Inep>(Constants.CollectionNames.Ineps);
            await ineps.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<Inep>(ix_Ineps_TermosPesquisa, new CreateIndexOptions()
            {
                Name = "ix_TermosPesquisa"
            }));
            await ineps.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<Inep>(ix_Ineps_Codigo, new CreateIndexOptions()
            {
                Name = "ix_Codigo"
            }));

            //princípios ativos
            var ix_PrincipiosAtivos_TermosPesquisa = Builders<PrincipioAtivo>.IndexKeys
                .Text(j => j.TermosPesquisa);

            var principiosAtivos = Database.GetCollection<PrincipioAtivo>(Constants.CollectionNames.PrincipiosAtivos);
            await principiosAtivos.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<PrincipioAtivo>(ix_PrincipiosAtivos_TermosPesquisa, new CreateIndexOptions()
            {
                Name = "ix_TermosPesquisa"
            }));

            //materiais
            var ix_Materiais_Tipo_TermosPesquisa = Builders<Material>.IndexKeys
                .Ascending(j => j.Tipo)
                .Text(j => j.TermosPesquisa);

            var ix_Materiais_Tipo = Builders<Material>.IndexKeys
                .Ascending(j => j.Tipo);

            var materiais = Database.GetCollection<Material>(Constants.CollectionNames.Materiais);
            await materiais.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<Material>(ix_Materiais_Tipo_TermosPesquisa, new CreateIndexOptions()
            {
                Name = "ix_Tipo_TermosPesquisa"
            }));
            await materiais.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<Material>(ix_Materiais_Tipo, new CreateIndexOptions()
            {
                Name = "ix_Tipos"
            }));

            //regiões
            var ix_Regioes_Tipo_TermosPesquisa = Builders<Regiao>.IndexKeys
                .Ascending(j => j.Tipo)
                .Text(j => j.TermosPesquisa);

            var ix_Regioes_Tipo = Builders<Regiao>.IndexKeys
                .Ascending(j => j.Tipo);

            var regioes = Database.GetCollection<Regiao>(Constants.CollectionNames.Regioes);
            await regioes.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<Regiao>(ix_Regioes_Tipo_TermosPesquisa, new CreateIndexOptions()
            {
                Name = "ix_Tipo_TermosPesquisa"
            }));
            await regioes.Indexes.CreateOneAsync(new MongoDB.Driver.CreateIndexModel<Regiao>(ix_Regioes_Tipo, new CreateIndexOptions()
            {
                Name = "ix_Tipos"
            }));
        }
    }
}
