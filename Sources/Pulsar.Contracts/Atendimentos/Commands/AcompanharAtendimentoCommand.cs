using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Pulsar.Common.Cqrs;

namespace Pulsar.Contracts.Atendimentos.Commands
{
    public class AcompanharAtendimentoCommand : ICommand
    {
        public ObjectId UsuarioId { get; set; }
        public ObjectId EstabelecimentoId { get; set; }
        public ObjectId AtendimentoId { get; set; }
    }
}
