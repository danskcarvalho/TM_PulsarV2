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
    [Route("v2/servicos")]
    [Authorize]
    public class ServicoController : PulsarController
    {
        public ServicoController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
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

        [HttpPost("{servicoId}")]
        public Task<ActionResult> Editar(ObjectId servicoId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{servicoId}")]
        public Task<ActionResult> Remover(ObjectId servicoId)
        {
            throw new NotImplementedException();
        }
    }
}
