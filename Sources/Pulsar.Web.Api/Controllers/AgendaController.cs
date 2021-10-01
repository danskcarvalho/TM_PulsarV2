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
    [Route("v2/agendas")]
    [Authorize]
    public class AgendaController : PulsarController
    {
        public AgendaController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
        {
        }

        [HttpGet]
        public Task<ActionResult> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{agendaId}")]
        public Task<ActionResult> GetAgendaDia()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{agendaId}/datas")]
        public Task<ActionResult> GetDatas(ObjectId agendaId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{agendaId}/horarios")]
        public Task<ActionResult> GetHorarios(ObjectId agendaId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{agendaId}/servicos")]
        public Task<ActionResult> GetServicos(ObjectId agendaId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{agendaId}/tiposatendimento")]
        public Task<ActionResult> GetTiposAtendimento(ObjectId agendaId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{agendaId}/profissionais")]
        public Task<ActionResult> GetProfissionais(ObjectId agendaId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{agendaId}/equipes")]
        public Task<ActionResult> GetEquipes(ObjectId agendaId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{agendaId}/escalas")]
        public Task<ActionResult> GetEscalas(ObjectId agendaId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public Task<ActionResult> Criar()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{agendaId}/escalas")]
        public Task<ActionResult> CriarEscalas(ObjectId agendaId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{agendaId}")]
        public Task<ActionResult> Editar(ObjectId agendaId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{agendaId}/bloquear")]
        public Task<ActionResult> Bloquear(ObjectId agendaId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{agendaId}/desbloquear")]
        public Task<ActionResult> Desbloquear(ObjectId agendaId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{agendaId}")]
        public Task<ActionResult> Remover(ObjectId agendaId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{agendaId}/escalas/{escalaId}")]
        public Task<ActionResult> RemoverEscalas(ObjectId agendaId, ObjectId escalaId)
        {
            throw new NotImplementedException();
        }
    }
}
