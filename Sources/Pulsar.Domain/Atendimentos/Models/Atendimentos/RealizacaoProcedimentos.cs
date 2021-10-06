using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class RealizacaoProcedimentos : AtendimentoComProfissional
    {
        public RealizacaoProcedimentos()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtendimento.RealizacaoProcedimentos;
        }

        public RealizacaoProcedimentos(ObjectId usuarioId, ObjectId atendimentoRaizId, ObjectId estabelecimentoId, ObjectId? equipeId, ObjectId pacienteId, Usuario profissional, ObjectId? servicoId, ObjectId? agendamentoId) : this()
        {
            EstabelecimentoId = estabelecimentoId;
            PacienteId = pacienteId;
            ServicoId = servicoId;
            Id = ObjectId.GenerateNewId();
            Status = StatusAtendimento.Aguardando;
            PacienteId = pacienteId;
            DataRegistro = Common.DataRegistro.CriadoHoje(usuarioId);
            ProfissionalId = profissional?.Id;
            AtendimentoRaizId = atendimentoRaizId;
            Especialidade = profissional?.GetLotacao(estabelecimentoId).EspecialidadeConselho.Especialidade;
            ConselhoProfissional = profissional?.GetLotacao(estabelecimentoId).EspecialidadeConselho.Conselho;
            EquipeId = equipeId;
            AgendamentoId = agendamentoId;
        }

        public Antropometria Antropometria { get; set; }
        public ExameFisico ExameFisico { get; set; }
        public MedicaoGlicemia MedicaoGlicemia { get; set; }
        public SinaisVitais SinaisVitais { get; set; }
        public Subjetivo Subjetivo { get; set; }
        public ObjectId AtendimentoPaiId { get; set; }
    }
}
