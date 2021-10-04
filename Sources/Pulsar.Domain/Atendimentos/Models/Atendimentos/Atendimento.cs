using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Common;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.FichasEsus.Models;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.Pastas.Models;
using Pulsar.Domain.Servicos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class Atendimento
    {
        public ObjectId Id { get; set; }
        public ObjectId EstabelecimentoId { get; set; }
        public ObjectId PacienteId { get; set; }
        public TipoAtendimento Tipo { get; set; }
        public List<ObjectId> FichasEsus { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }

        public static Atendimento Criar(TipoAtendimento tipo,
            ObjectId usuarioId, ObjectId atendimentoRaizId,
            Estabelecimento estabelecimento, ObjectId? equipeId, ObjectId pacienteId, 
            Usuario profissional, ObjectId? servicoId, ObjectId? agendamentoId,
            string justificativa)
        {
            switch (tipo)
            {
                case TipoAtendimento.Medico:
                    return new AtendimentoMedico(usuarioId, atendimentoRaizId, estabelecimento.Id, equipeId, pacienteId, profissional, servicoId, agendamentoId);
                case TipoAtendimento.Enfermagem:
                    return new AtendimentoEnfermagem(usuarioId, atendimentoRaizId, estabelecimento.Id, equipeId, pacienteId, profissional, servicoId, agendamentoId);
                case TipoAtendimento.AuxiliarEnfermagem:
                    return new AtendimentoAuxiliarEnfermagem(usuarioId, atendimentoRaizId, estabelecimento.Id, equipeId, pacienteId, profissional, servicoId, agendamentoId);
                case TipoAtendimento.Vacinacao:
                    return new AtendimentoVacinacao(usuarioId, atendimentoRaizId, estabelecimento.Id, equipeId, pacienteId, profissional, servicoId, agendamentoId);
                case TipoAtendimento.Odontologico:
                    return new AtendimentoOdontologico(usuarioId, atendimentoRaizId, estabelecimento, equipeId, pacienteId, profissional, servicoId, agendamentoId);
                case TipoAtendimento.AlteracaoProntuario:
                    return new AlteracaoProntuario(usuarioId, atendimentoRaizId, estabelecimento.Id, pacienteId, profissional, justificativa);
                case TipoAtendimento.EscutaInicial:
                    return new EscutaInicial(usuarioId, atendimentoRaizId, estabelecimento.Id, equipeId, pacienteId, profissional, servicoId, agendamentoId);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
