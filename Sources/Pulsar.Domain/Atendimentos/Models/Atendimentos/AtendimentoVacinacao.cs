using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Agendamentos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoVacinacao : AtendimentoComProfissional
    {
        public AtendimentoVacinacao()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtendimento.Vacinacao;
        }

        public AtendimentoVacinacao(ObjectId usuarioId, ObjectId atendimentoRaizId, ObjectId estabelecimentoId, ObjectId? equipeId, ObjectId pacienteId, Usuario profissional, ObjectId? servicoId, ObjectId? agendamentoId) : base()
        {
            EstabelecimentoId = estabelecimentoId;
            PacienteId = pacienteId;
            ServicoId = servicoId;
            Id = ObjectId.GenerateNewId();
            Status = StatusAtendimento.Aguardando;
            EstabelecimentoId = estabelecimentoId;
            PacienteId = pacienteId;
            FichasEsus = new List<ObjectId>();
            DataRegistro = Common.DataRegistro.CriadoHoje(usuarioId);
            ProfissionalId = profissional.Id;
            UltimosServicos = new List<ObjectId>();
            AtendimentoRaizId = atendimentoRaizId;
            HistoricoStatus = new HistoricoStatus()
            {
                MudancasStatus = new List<HistoricoStatusItem>()
                {
                    new HistoricoStatusItem()
                    {
                        StatusAnterior = null,
                        StatusPosterior = StatusAtendimento.Aguardando,
                        Ocorrencia = DateTime.Now
                    }
                }
            };
            Realizacao = new RealizacaoAtendimento();
            Especialidade = profissional.GetLotacao(estabelecimentoId).EspecialidadeConselho.Especialidade;
            ConselhoProfissional = profissional.GetLotacao(estabelecimentoId).EspecialidadeConselho.Conselho;
            EquipeId = equipeId;
            AgendamentoId = agendamentoId;
            ProcedimentosReportados = new List<Global.Models.ProcedimentoResumido>();
            Documentos = new List<Pastas.Models.PastaArquivo>();
            Acompanhamentos = new List<ObjectId>();
            CondicoesPaciente = new CondicoesPacienteVacinacao();
            Aprazadas = new List<AgendamentoVacinacao>();
        }

        public CondicoesPacienteVacinacao CondicoesPaciente { get; set; }
        public List<AgendamentoVacinacao> Aprazadas { get; set; }
    }
}
