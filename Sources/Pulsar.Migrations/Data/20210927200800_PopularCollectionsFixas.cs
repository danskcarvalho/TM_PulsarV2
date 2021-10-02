using Pulsar.Common;
using Pulsar.Domain.Global.Models;
using Pulsar.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Pulsar.Migrations.Data
{
    [Migration(20210927200800)]
    public class PopularCollectionsFixas : Migration
    {
        public override async Task Up()
        {
            var condicoesSaudeCollection = GetCollection<ChaveCondicaoSaude>(Constants.CollectionNames.ChavesCondicaoSaude);
            var dentesCollection = GetCollection<Dente>(Constants.CollectionNames.Dentes);
            var diagnosticosCollection = GetCollection<Diagnostico>(Constants.CollectionNames.Diagnosticos);
            var etniasCollection = GetCollection<Etnia>(Constants.CollectionNames.Etnias);
            var inepsCollection = GetCollection<Inep>(Constants.CollectionNames.Ineps);
            var materiaisCollection = GetCollection<Material>(Constants.CollectionNames.Materiais);
            var perguntasPuericulturaCollection = GetCollection<PerguntaPuericultura>(Constants.CollectionNames.PerguntasPuericultura);
            var principiosAtivosCollection = GetCollection<PrincipioAtivo>(Constants.CollectionNames.PrincipiosAtivos);
            var regioesCollection = GetCollection<Regiao>(Constants.CollectionNames.Regioes);

            //condições de saúde
            var linhas = await File.ReadAllLinesAsync(@"Data\Files\condicoes_saude.txt");
            var condicoesSaude = new List<ChaveCondicaoSaude>();
            foreach (var item in linhas)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                condicoesSaude.Add(item.FromBson<ChaveCondicaoSaude>());
            }

            await condicoesSaudeCollection.DeleteManyAsync(e => true);
            foreach (var list in condicoesSaude.Partition(500))
            {
                await condicoesSaudeCollection.InsertManyAsync(list);
            }

            //dentes
            linhas = await File.ReadAllLinesAsync(@"Data\Files\dentes.txt");
            var dentes = new List<Dente>();
            foreach (var item in linhas)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                dentes.Add(item.FromBson<Dente>());
            }

            await dentesCollection.DeleteManyAsync(e => true);
            foreach (var list in dentes.Partition(500))
            {
                await dentesCollection.InsertManyAsync(list);
            }

            //diagnósticos
            linhas = await File.ReadAllLinesAsync(@"Data\Files\diagnosticos.txt");
            var diagnosticos = new List<Diagnostico>();
            foreach (var item in linhas)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                diagnosticos.Add(item.FromBson<Diagnostico>());
            }

            await diagnosticosCollection.DeleteManyAsync(e => true);
            foreach (var list in diagnosticos.Partition(500))
            {
                await diagnosticosCollection.InsertManyAsync(list);
            }

            //perguntas puericultura
            linhas = await File.ReadAllLinesAsync(@"Data\Files\perguntas_puericultura.txt");
            var perguntasPuericultura = new List<PerguntaPuericultura>();
            foreach (var item in linhas)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                perguntasPuericultura.Add(item.FromBson<PerguntaPuericultura>());
            }

            await perguntasPuericulturaCollection.DeleteManyAsync(e => true);
            foreach (var list in perguntasPuericultura.Partition(500))
            {
                await perguntasPuericulturaCollection.InsertManyAsync(list);
            }

            //etnias
            linhas = await File.ReadAllLinesAsync(@"Data\Files\etnias.txt");
            var etnias = new List<Etnia>();
            foreach (var item in linhas)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                etnias.Add(item.FromBson<Etnia>());
            }

            await etniasCollection.DeleteManyAsync(e => true);
            foreach (var list in etnias.Partition(500))
            {
                await etniasCollection.InsertManyAsync(list);
            }

            //ineps
            linhas = await File.ReadAllLinesAsync(@"Data\Files\ineps.txt");
            var ineps = new List<Inep>();
            foreach (var item in linhas)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                ineps.Add(item.FromBson<Inep>());
            }

            await inepsCollection.DeleteManyAsync(e => true);
            foreach (var list in ineps.Partition(500))
            {
                await inepsCollection.InsertManyAsync(list);
            }

            //materiais
            linhas = await File.ReadAllLinesAsync(@"Data\Files\materiais.txt");
            var materiais = new List<Material>();
            foreach (var item in linhas)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                materiais.Add(item.FromBson<Material>());
            }

            await materiaisCollection.DeleteManyAsync(e => true);
            foreach (var list in materiais.Partition(500))
            {
                await materiaisCollection.InsertManyAsync(list);
            }

            //principios ativos
            linhas = await File.ReadAllLinesAsync(@"Data\Files\principios_ativos.txt");
            var principiosAtivos = new List<PrincipioAtivo>();
            foreach (var item in linhas)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                principiosAtivos.Add(item.FromBson<PrincipioAtivo>());
            }

            await principiosAtivosCollection.DeleteManyAsync(e => true);
            foreach (var list in principiosAtivos.Partition(500))
            {
                await principiosAtivosCollection.InsertManyAsync(list);
            }

            //regiões
            linhas = await File.ReadAllLinesAsync(@"Data\Files\regioes.txt");
            var regioes = new List<Regiao>();
            foreach (var item in linhas)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                regioes.Add(item.FromBson<Regiao>());
            }

            await regioesCollection.DeleteManyAsync(e => true);
            foreach (var list in regioes.Partition(500))
            {
                await regioesCollection.InsertManyAsync(list);
            }
        }
    }
}
