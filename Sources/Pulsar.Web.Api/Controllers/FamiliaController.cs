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
    [Route("v2/familias")]
    [Authorize]
    public class FamiliaController : PulsarController
    {
        public FamiliaController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
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

        [HttpPost("{familiaId}")]
        public Task<ActionResult> Editar(ObjectId familiaId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{familiaId}")]
        public Task<ActionResult> Remover(ObjectId familiaId)
        {
            throw new NotImplementedException();
        }
    }
}
