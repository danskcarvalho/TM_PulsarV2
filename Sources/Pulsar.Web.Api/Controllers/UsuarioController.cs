using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using Pulsar.Common.Cqrs;
using Pulsar.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulsar.Web.Api.Controllers
{
    [Route("v2/usuarios")]
    [Authorize]
    public class UsuarioController : PulsarController
    {
        public UsuarioController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
        {
        }

        [HttpGet]
        public Task<ActionResult> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public Task<ActionResult> Criar()
        {
            throw new NotImplementedException();
        }

        [HttpPost("{usuarioId}")]
        public Task<ActionResult> Editar(ObjectId usuarioId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{usuarioId}/senha")]
        public Task<ActionResult> RedefinirSenha(ObjectId usuarioId)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpPost("senha")]
        public Task<ActionResult> AnonimoRedefinirSenha()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gestor reenvia e-mail para usuário que precisa recuperar a senha ou ativar a conta.
        /// </summary>
        /// <param name="usuarioId">Id do usuário que precisa recuperar a senha ou ativar a conta.</param>
        /// <returns></returns>
        [HttpPost("{usuarioId}/email")]
        public Task<ActionResult> GestorReenviarEmail(ObjectId usuarioId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// O próprio usuário requisita reenviar e-mail para recuperar sua senha ou ativar a sua conta.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("email")]
        public Task<ActionResult> AnonimoReenviarEmail()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{usuarioId}")]
        public Task<ActionResult> Remover(ObjectId usuarioId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{usuarioId}/lotacoes/estabelecimentos")]
        public Task<ActionResult> GetLotacoesEstabelecimentos(ObjectId usuarioId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{usuarioId}/lotacoes/estabelecimentos")]
        public Task<ActionResult> SalvarLotacoesEstabelecimentos(ObjectId usuarioId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{usuarioId}/lotacoes/redeestabelecimentos")]
        public Task<ActionResult> GetLotacoesRedeEstabelecimentos(ObjectId usuarioId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{usuarioId}/lotacoes/redeestabelecimentos")]
        public Task<ActionResult> SalvarLotacoesRedeEstabelecimentos(ObjectId usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
