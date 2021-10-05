using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Common.Exceptions;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Acompanhamentos.Models
{
    public class PreNatalAcompanhamento : Acompanhamento
    {
        public PreNatalAcompanhamento()
        {
            Tipo = Pulsar.Common.Enumerations.AcompanhamentoTipo.PreNatal;
        }

        public FinalizacaoPreNatal Finalizacao { get; set; }
        public List<PreNatalAtendimento> DadosAtendimentos { get; set; }

        public override async Task Entrar(ObjectId usuarioId, AtendimentoComProfissional atendimento, Container container)
        {
            if (atendimento is AtendimentoIndividual ai)
                InserirDadosAtendimento(usuarioId, ai);
            await base.Entrar(usuarioId, atendimento, container);
        }

        private void InserirDadosAtendimento(ObjectId usuarioId, AtendimentoIndividual ai)
        {
            var dados = DadosAtendimentos.FirstOrDefault(da => da.AtendimentoId == ai.Id);
            if (dados == null)
            {
                dados = new PreNatalAtendimento()
                {
                    Antropometria = ai.Antropometria,
                    AtendimentoId = ai.Id,
                    DataRegistro = DataRegistro.CriadoHoje(usuarioId),
                    MedicaoGlicemia = ai.MedicaoGlicemia,
                    PreNatal = ai.PreNatal,
                    Puerperio = ai.Puerperio,
                    SaudeMulher = ai.SaudeMulher,
                    SinaisVitais = ai.SinaisVitais
                };
                DadosAtendimentos.Add(dados);
            }
            else
            {
                dados.Antropometria = ai.Antropometria;
                dados.MedicaoGlicemia = ai.MedicaoGlicemia;
                dados.PreNatal = ai.PreNatal;
                dados.Puerperio = ai.Puerperio;
                dados.SaudeMulher = ai.SaudeMulher;
                dados.SinaisVitais = ai.SinaisVitais;
                dados.DataRegistro.Atualizado(usuarioId);
            } 
        }
    }
}
