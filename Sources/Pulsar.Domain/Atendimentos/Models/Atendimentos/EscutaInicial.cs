using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class EscutaInicial : AtendimentoComProfissional 
    {
        public EscutaInicial()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtendimento.EscutaInicial;
        }

        public EscutaInicial(ObjectId usuarioId, ObjectId atendimentoRaizId, Estabelecimento estabelecimento, ObjectId? equipeId, ObjectId pacienteId, Usuario profissional, ObjectId? servicoId, ObjectId? agendamentoId) : this()
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

        public Subjetivo Subjetivo { get; set; }
        public Objetivo Objetivo { get; set; }
        public Antropometria Antropometria { get; set; }
        public SinaisVitais SinaisVitais { get; set; }
        public MedicaoGlicemia MedicaoGlicemia { get; set; }
        public ExameFisico ExameFisico { get; set; }
        public RiscoAtendimento? Risco { get; set; }
    }
}
