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
    [Route("v2/acompanhamentos")]
    [Authorize]
    public class AcompanhamentoController : PulsarController
    {
        public AcompanhamentoController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
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

        [HttpDelete("{acompanhamentoId}")]
        public Task<ActionResult> Cancelar(ObjectId acompanhamentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{acompanhamentoId}/entrar")]
        public Task<ActionResult> Entrar(ObjectId acompanhamentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{acompanhamentoId}/sair")]
        public Task<ActionResult> Sair(ObjectId acompanhamentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{acompanhamentoId}/finalizar")]
        public Task<ActionResult> Finalizar(ObjectId acompanhamentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{acompanhamentoId}/reabrir")]
        public Task<ActionResult> Reabrir(ObjectId acompanhamentoId)
        {
            throw new NotImplementedException();
        }
    }
}
