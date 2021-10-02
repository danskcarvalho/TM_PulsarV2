using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MongoDB.Bson;
using Pulsar.Common.Cqrs;
using Pulsar.Common.Enumerations;

namespace Pulsar.Contracts.Atendimentos.Commands
{
    /// <summary>
    /// CriarAtendimentoCommand
    /// </summary>
    public class CriarAtendimentoCommand : ICommand
    {
        /// <summary>
        /// Id do usuário logado.
        /// </summary>
        public ObjectId? UsuarioId { get; set; }
        public ObjectId? EstabelecimentoId { get; set; }
        public ObjectId? PacienteId { get; set; }
        public PacienteAnonimoModel PacienteAnonimo { get; set; }
        public CategoriaAtendimento? Categoria { get; set; }
        public List<AtendimentoModel> Atendimentos { get; set; }

        public class PacienteAnonimoModel
        {
            /// <summary>
            /// Nome do paciente anônimo.
            /// </summary>
            public string Nome { get; set; }
            public Sexo? Sexo { get; set; }
            public DateTime? DataNascimento { get; set; }
        }

        public class AtendimentoModel
        {
            public TipoAtendimento? Tipo { get; set; }
            public ObjectId? ServicoId { get; set; }
            public ObjectId? ProfissionalId { get; set; }
        }
    }

    public class CriarAtendimentoCommandValidator : AbstractValidator<CriarAtendimentoCommand>
    {
        public CriarAtendimentoCommandValidator()
        {
            RuleFor(x => x.UsuarioId).NotNull();
            RuleFor(x => x.EstabelecimentoId).NotNull();
        }
    }
}
