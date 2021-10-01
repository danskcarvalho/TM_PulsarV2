using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Common.Cqrs;

namespace Pulsar.Contracts.Usuarios.Results
{
    public class LoginUsuarioResult
    {
        /// <summary>
        /// Token de acesso.
        /// </summary>
        public string Token { get; set; }
    }
}
