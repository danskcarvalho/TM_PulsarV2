using Pulsar.Common.Cqrs;
using Pulsar.Contracts.Results.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Contracts.Requests.Usuarios
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
