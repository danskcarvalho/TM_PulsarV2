using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using Pulsar.Common.Cqrs;
using Pulsar.Contracts.Usuarios.Requests;
using Pulsar.Contracts.Usuarios.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulsar.Web.Api.Controllers
{
    [Route("v2/tokens")]
    public class TokenController : PulsarController
    {
        public TokenController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
        {
        }

        /// <summary>
        /// Cria um token de acesso à API. Esta action deve ser a primeira a ser chamada antes de acessar qualquer outra action da API. 
        /// Este token deve ser passado em subsequentes chamadas à API no header Authorization no formato "Bearer token" (sem as aspas). Onde "token" deve ser substituído
        /// pelo token retornado por esta action. O token retornado tem validade de 30 minutos, em média.
        /// </summary>
        /// <param name="request">E-mail e senha do usuário.</param>
        /// <returns>Token de acesso ao sistema.</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<LoginUsuarioResult>> Criar([FromBody] LoginUsuarioRequest request)
        {
            var result = RequestBus.Request<LoginUsuarioRequest, LoginUsuarioResult>(request);
            return Ok(new LoginUsuarioResult()
            {
                Token = CreateToken(new Models.UserClaims()
                {
                    Id = ObjectId.GenerateNewId(),
                    Role = $"_/{ObjectId.GenerateNewId()}"
                })
            });
        }

        [HttpPost("ir/redeestabelecimentos")]
        public Task<ActionResult> IrParaRedeEstabelecimentos()
        {
            throw new NotImplementedException();
        }

        [HttpPost("ir/estabelecimentos")]
        public Task<ActionResult> IrParaEstabelecimentos()
        {
            throw new NotImplementedException();
        }
    }
}
