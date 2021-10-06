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
    public class AtendimentoMedico : AtendimentoIndividual
    {
        public AtendimentoMedico()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtendimento.Medico;
        }

        public AtendimentoMedico(ObjectId usuarioId, ObjectId atendimentoRaizId,
            Estabelecimento estabelecimento, ObjectId? equipeId, ObjectId pacienteId, Usuario profissional, 
            ObjectId? servicoId, ObjectId? agendamentoId) : this()
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

            if (agendamentoId != null)
                TipoAtendimentoEsus = Pulsar.Common.Enumerations.TipoAtendimentoEsus.ConsultaAgendada;
            else
                TipoAtendimentoEsus = Pulsar.Common.Enumerations.TipoAtendimentoEsus.ConsultaDia;
        }
    }
}
