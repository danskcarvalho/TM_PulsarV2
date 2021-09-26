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
    [Route("v2/usuarios")]
    [Authorize]
    public class UsuarioController : PulsarController
    {
        public UsuarioController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
        {
        }

        [HttpGet]
        public async Task<ActionResult> Buscar()
        {
            return Ok();
        }
    }
}
