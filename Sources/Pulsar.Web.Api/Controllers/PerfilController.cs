using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pulsar.Common.Cqrs;
using Pulsar.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulsar.Web.Api.Controllers
{
    [Route("v2/perfis")]
    [Authorize]
    public class PerfilController : PulsarController
    {
        public PerfilController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
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

        [HttpPost("{perfilId}")]
        public Task<ActionResult> Editar()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{perfilId}")]
        public Task<ActionResult> Remover()
        {
            throw new NotImplementedException();
        }
    }
}
