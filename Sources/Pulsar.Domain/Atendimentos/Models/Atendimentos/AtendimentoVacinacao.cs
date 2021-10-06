using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Agendamentos.Models;
using Pulsar.Domain.Estabelecimentos.Models;
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

        public AtendimentoVacinacao(ObjectId usuarioId, ObjectId atendimentoRaizId, Estabelecimento estabelecimento, ObjectId? equipeId, ObjectId pacienteId, Usuario profissional, ObjectId? servicoId, ObjectId? agendamentoId) : this()
        {
            EstabelecimentoId = estabelecimento.Id;
            PacienteId = pacienteId;
            ServicoId = servicoId;
            Id = ObjectId.GenerateNewId();
            Status = StatusAtendimento.Aguardando;
            PacienteId = pacienteId;
            DataRegistro = Common.DataRegistro.CriadoHoje(usuarioId);
            ProfissionalId = profissional?.Id;
            AtendimentoRaizId = atendimentoRaizId;
            Especialidade = profissional?.GetLotacao(estabelecimento)?.EspecialidadeConselho.Especialidade;
            ConselhoProfissional = profissional?.GetLotacao(estabelecimento)?.EspecialidadeConselho.Conselho;
            EquipeId = equipeId;
            AgendamentoId = agendamentoId;
        }

        public CondicoesPacienteVacinacao CondicoesPaciente { get; set; } = new CondicoesPacienteVacinacao();
        public List<AgendamentoVacinacao> Aprazadas { get; set; } = new List<AgendamentoVacinacao>();
    }
}
