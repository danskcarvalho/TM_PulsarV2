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
    [Route("v2/agendamentos")]
    [Authorize]
    public class AgendamentoController : PulsarController
    {
        public AgendamentoController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
        {
        }

        [HttpGet]
        public Task<ActionResult> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{agendamentoId}/tiposatendimento")]
        public Task<ActionResult> GetTiposAtendimento(ObjectId agendamentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public Task<ActionResult> Criar()
        {
            throw new NotImplementedException();
        }

        [HttpPost("{agendamentoId}")]
        public Task<ActionResult> Editar(ObjectId agendamentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{agendamentoId}/confirmar")]
        public Task<ActionResult> Confirmar(ObjectId agendamentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{agendamentoId}/chegada")]
        public Task<ActionResult> InformarChegada(ObjectId agendamentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("transferir")]
        public Task<ActionResult> Transferir()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{agendamentoId}")]
        public Task<ActionResult> Cancelar(ObjectId agendamentoId)
        {
            throw new NotImplementedException();
        }
    }
}
