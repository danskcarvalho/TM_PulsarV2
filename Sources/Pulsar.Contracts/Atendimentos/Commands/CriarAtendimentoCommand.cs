using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MongoDB.Bson;
using Pulsar.Common;
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
        public ObjectId UsuarioId { get; set; }
        public ObjectId EstabelecimentoId { get; set; }
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
            /// <summary>
            /// Uso interno.
            /// </summary>
            public ObjectId? AtendimentoId { get; set; }
            /// <summary>
            /// Justificativa para alteração do prontuário.
            /// </summary>
            public string Justificativa { get; set; }
        }
    }

    public class CriarAtendimentoCommandValidator : AbstractValidator<CriarAtendimentoCommand>
    {
        public CriarAtendimentoCommandValidator()
        {
            RuleFor(x => x).Must(x => x.PacienteId != null || x.PacienteAnonimo != null).WithMessage("É necessário informar o paciente.");
            RuleFor(x => x.PacienteAnonimo).ChildRules(pa =>
            {
                pa.RuleFor(x => x.Nome).NotEmpty();
                pa.RuleFor(x => x.Sexo).NotNull();
                pa.RuleFor(x => x.DataNascimento).NotNull().Must(dt => dt < DateTime.Today).WithMessage("Data de nascimento não pode estar no futuro.");
            }).When(x => x.PacienteAnonimo != null);
            RuleFor(x => x.Categoria).NotNull().IsInEnum();
            RuleFor(x => x.Atendimentos)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(x => x.All(y => y != null)).WithMessage("Elemento nulo em Atendimentos.");
            RuleFor(x => x).Must(x => x.Atendimentos.Count == 1)
                .WithMessage("Alteração de prontuário não pode ser criada com outro atendimentos.")
                .When(x => x.Atendimentos != null && x.Atendimentos.Any(y => y.Tipo == TipoAtendimento.AlteracaoProntuario));
            RuleFor(x => x).Must(x => x.Atendimentos.Count == 1)
                .WithMessage("Atendimento individual só pode ser criado com um único atendimento.")
                .When(x => x.Atendimentos != null && x.Categoria == CategoriaAtendimento.Individual);
            RuleForEach(x => x.Atendimentos).ChildRules(a =>
            {
                a.RuleFor(x => x.Tipo).NotNull().IsInEnum();
                a.RuleFor(x => x.Tipo).Must(x => x.Value.ValidoParaCriacao()).WithMessage("Tipo de atendimento inválido.").When(x => x.Tipo != null);
                a.RuleFor(x => x.Justificativa).NotEmpty().When(x => x.Tipo == TipoAtendimento.AlteracaoProntuario);
                a.RuleFor(x => x.ProfissionalId).Null().When(x => x.Tipo == TipoAtendimento.AlteracaoProntuario);
                a.RuleFor(x => x.ServicoId).Null().When(x => x.Tipo == TipoAtendimento.AlteracaoProntuario);
            });
        }
    }
}
