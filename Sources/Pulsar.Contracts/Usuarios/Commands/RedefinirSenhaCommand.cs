using MongoDB.Bson;
using Pulsar.Common.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Contracts.Usuarios.Commands
{
    public class RedefinirSenhaCommand : ICommand
    {
        public ObjectId UsuarioId { get; set; }
        public string SenhaAntiga { get; set; }
        public string SenhaNova { get; set; }
    }
}
