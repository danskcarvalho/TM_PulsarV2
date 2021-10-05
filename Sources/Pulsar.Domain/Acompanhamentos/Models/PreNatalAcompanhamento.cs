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

        protected override void InserirDadosAtendimento(ObjectId usuarioId, AtendimentoComProfissional atendimento)
        {
            var dados = Atendimentos.FirstOrDefault(da => da.AtendimentoId == atendimento.Id) as PreNatalAtendimento;
            var individual = atendimento as AtendimentoIndividual;
            if (dados == null)
            {
                dados = new PreNatalAtendimento()
                {
                    Antropometria = individual?.Antropometria,
                    AtendimentoId = atendimento.Id,
                    DataRegistro = DataRegistro.CriadoHoje(usuarioId),
                    MedicaoGlicemia = individual?.MedicaoGlicemia,
                    PreNatal = individual?.PreNatal,
                    Puerperio = individual?.Puerperio,
                    SaudeMulher = individual?.SaudeMulher,
                    SinaisVitais = individual?.SinaisVitais,
                    ConselhoProfissional = atendimento.ConselhoProfissional,
                    Especialidade = atendimento.Especialidade,
                    HistoricoStatus = atendimento.HistoricoStatus,
                    ProfissionalId = atendimento.ProfissionalId,
                    Realizacao = atendimento.Realizacao,
                    ServicoId = atendimento.ServicoId,
                    Status = atendimento.Status
                };
                Atendimentos.Add(dados);
            }
            else
            {
                dados.Antropometria = individual?.Antropometria;
                dados.AtendimentoId = atendimento.Id;
                dados.DataRegistro = DataRegistro.CriadoHoje(usuarioId);
                dados.MedicaoGlicemia = individual?.MedicaoGlicemia;
                dados.PreNatal = individual?.PreNatal;
                dados.Puerperio = individual?.Puerperio;
                dados.SaudeMulher = individual?.SaudeMulher;
                dados.SinaisVitais = individual?.SinaisVitais;
                dados.ConselhoProfissional = atendimento.ConselhoProfissional;
                dados.Especialidade = atendimento.Especialidade;
                dados.HistoricoStatus = atendimento.HistoricoStatus;
                dados.ProfissionalId = atendimento.ProfissionalId;
                dados.Realizacao = atendimento.Realizacao;
                dados.ServicoId = atendimento.ServicoId;
                dados.Status = atendimento.Status;
                dados.DataRegistro.Atualizado(usuarioId);
            }
        }
    }
}
