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
    [Route("v2/prontuarios")]
    [Authorize]
    public class ProntuarioController : PulsarController
    {
        public ProntuarioController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
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

        [HttpPost("{prontuarioId}")]
        public Task<ActionResult> Editar(ObjectId prontuarioId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{prontuarioId}")]
        public Task<ActionResult> Remover(ObjectId prontuarioId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{prontuarioId}/resultado")]
        public Task<ActionResult> InformarResultado(ObjectId prontuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
