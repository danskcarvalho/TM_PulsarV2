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
    [Route("v2/atendimentos/filas")]
    [Authorize]
    public class FilaAtendimentoController : PulsarController
    {
        public FilaAtendimentoController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
        {
        }

        [HttpGet]
        public Task<ActionResult> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("geral")]
        public Task<ActionResult> GetFilaGeral()
        {
            throw new NotImplementedException();
        }

        [HttpPost("filas/{filaId}/item/{itemId}/iniciar")]
        public Task<ActionResult> IniciarAtendimento(ObjectId filaId, ObjectId itemId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("filas/{filaId}/item/{itemId}")]
        public Task<ActionResult> Remover(ObjectId filaId, ObjectId itemId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("filas/{filaId}/item/{itemId}/transferir")]
        public Task<ActionResult> Transferir(ObjectId filaId, ObjectId itemId)
        {
            throw new NotImplementedException();
        }
    }
}
