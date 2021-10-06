using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Common.Exceptions;
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
    public class Atendimento : System.ComponentModel.ISupportInitialize
    {
        private bool _Initializing = false;

        public ObjectId Id { get; set; }
        public ObjectId EstabelecimentoId { get; set; }
        public ObjectId PacienteId { get; set; }
        public TipoAtendimento Tipo { get; set; }
        public List<ObjectId> FichasEsus { get; set; } = new List<ObjectId>();
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
                    return new AtendimentoMedico(usuarioId, atendimentoRaizId, estabelecimento, equipeId, pacienteId, profissional, servicoId, agendamentoId);
                case TipoAtendimento.Enfermagem:
                    return new AtendimentoEnfermagem(usuarioId, atendimentoRaizId, estabelecimento, equipeId, pacienteId, profissional, servicoId, agendamentoId);
                case TipoAtendimento.AuxiliarEnfermagem:
                    return new AtendimentoAuxiliarEnfermagem(usuarioId, atendimentoRaizId, estabelecimento, equipeId, pacienteId, profissional, servicoId, agendamentoId);
                case TipoAtendimento.Vacinacao:
                    return new AtendimentoVacinacao(usuarioId, atendimentoRaizId, estabelecimento, equipeId, pacienteId, profissional, servicoId, agendamentoId);
                case TipoAtendimento.Odontologico:
                    return new AtendimentoOdontologico(usuarioId, atendimentoRaizId, estabelecimento, equipeId, pacienteId, profissional, servicoId, agendamentoId);
                case TipoAtendimento.AlteracaoProntuario:
                    return new AlteracaoProntuario(usuarioId, atendimentoRaizId, estabelecimento, pacienteId, profissional, justificativa);
                case TipoAtendimento.EscutaInicial:
                    return new EscutaInicial(usuarioId, atendimentoRaizId, estabelecimento, equipeId, pacienteId, profissional, servicoId, agendamentoId);
                case TipoAtendimento.RealizacaoProcedimentos:
                    return new RealizacaoProcedimentos(usuarioId, atendimentoRaizId, estabelecimento, equipeId, pacienteId, profissional, servicoId, agendamentoId);
                default:
                    throw new InvalidOperationException();
            }
        }

        public virtual Task Acompanhar(Usuario usuario, Estabelecimento estabelecimento, Container container)
        {
            throw new PulsarException(PulsarErrorCode.Unknown);
        }

        public virtual Task Reabrir(Usuario usuario, Estabelecimento estabelecimento, Container container)
        {
            throw new PulsarException(PulsarErrorCode.BadRequest, "Atendimento não pode ser reaberto.");
        }

        public virtual Task Abrir(ObjectId usuarioId, ObjectId filaAtendimentosId, Container container)
        {
            throw new PulsarException(PulsarErrorCode.BadRequest, "Atendimento não pode ser aberto.");
        }

        public bool IsInitializing => _Initializing;

        void System.ComponentModel.ISupportInitialize.BeginInit()
        {
            _Initializing = true;
        }
        void System.ComponentModel.ISupportInitialize.EndInit()
        {
            _Initializing = false;
        }
    }
}
