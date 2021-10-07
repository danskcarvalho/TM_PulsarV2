using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MongoDB.Bson;
using Pulsar.Common;
using Pulsar.Common.Cqrs;
using Pulsar.Common.Enumerations;

namespace Pulsar.Contracts.FilasAtendimentos.Commands
{
    public class IniciarAtendimentoCommand : ICommand
    {
        public ObjectId UsuarioId { get; set; }
        public ObjectId EstabelecimentoId { get; set; }
        public ObjectId? ItemId { get; set; }
        public ObjectId? AtendimentoId { get; set; }
        public TipoAtendimento? TipoAtendimento { get; set; }
    }

    public class IniciarAtendimentoCommandValidator : AbstractValidator<IniciarAtendimentoCommand>
    {
        public IniciarAtendimentoCommandValidator()
        {
            RuleFor(x => x.ItemId).NotNull();
            RuleFor(x => x.TipoAtendimento).Cascade(CascadeMode.Stop)
                .IsInEnum()
                .Must(x => x.Value.ValidoParaCriacao()).When(x => x.TipoAtendimento != null);
        }
    }
}
