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
    public class PuericulturaAcompanhamento : Acompanhamento
    {
        public PuericulturaAcompanhamento()
        {
            Tipo = Pulsar.Common.Enumerations.AcompanhamentoTipo.Puericultura;
        }

        protected override void InserirDadosAtendimento(ObjectId usuarioId, AtendimentoComProfissional atendimento)
        {
            var dados = Atendimentos.FirstOrDefault(da => da.AtendimentoId == atendimento.Id) as PuericulturaAtendimento;
            var individual = atendimento as AtendimentoIndividual;
            if (dados == null)
            {
                dados = new PuericulturaAtendimento()
                {
                    Antropometria = individual?.Antropometria,
                    AtendimentoId = atendimento.Id,
                    DataRegistro = DataRegistro.CriadoHoje(usuarioId),
                    MedicaoGlicemia = individual?.MedicaoGlicemia,
                    SinaisVitais = individual?.SinaisVitais,
                    ConselhoProfissional = atendimento.ConselhoProfissional,
                    Especialidade = atendimento.Especialidade,
                    HistoricoStatus = atendimento.HistoricoStatus,
                    ProfissionalId = atendimento.ProfissionalId,
                    Realizacao = atendimento.Realizacao,
                    ServicoId = atendimento.ServicoId,
                    Status = atendimento.Status,
                    Puericultura = individual?.Puericultura
                };
                Atendimentos.Add(dados);
            }
            else
            {
                dados.Antropometria = individual?.Antropometria;
                dados.AtendimentoId = atendimento.Id;
                dados.DataRegistro = DataRegistro.CriadoHoje(usuarioId);
                dados.MedicaoGlicemia = individual?.MedicaoGlicemia;
                dados.SinaisVitais = individual?.SinaisVitais;
                dados.ConselhoProfissional = atendimento.ConselhoProfissional;
                dados.Especialidade = atendimento.Especialidade;
                dados.HistoricoStatus = atendimento.HistoricoStatus;
                dados.ProfissionalId = atendimento.ProfissionalId;
                dados.Realizacao = atendimento.Realizacao;
                dados.ServicoId = atendimento.ServicoId;
                dados.Status = atendimento.Status;
                dados.Puericultura = individual?.Puericultura;
                dados.DataRegistro.Atualizado(usuarioId);
            }
        }
    }
}
