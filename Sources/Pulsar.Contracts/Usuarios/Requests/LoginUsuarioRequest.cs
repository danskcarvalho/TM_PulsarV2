using Pulsar.Common.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common.Cqrs;

namespace Pulsar.Contracts.Usuarios.Requests
{
    public class LoginUsuarioRequest : IRequest
    {
        /// <summary>
        /// E-mail do usuário.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Senha de acesso.
        /// </summary>
        public string Senha { get; set; }
    }
}
