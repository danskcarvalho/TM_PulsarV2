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
    [Route("v2/estabelecimentos")]
    [Authorize]
    public class EstabelecimentoController : PulsarController
    {
        public EstabelecimentoController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
        {
        }

        [HttpGet]
        public Task<ActionResult> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{estabelecimentoId}/servicos")]
        public Task<ActionResult> GetServicos(ObjectId estabelecimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{estabelecimentoId}/tiposatendimento")]
        public Task<ActionResult> GetTiposAtendimento(ObjectId estabelecimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{estabelecimentoId}/profissionais")]
        public Task<ActionResult> GetProfissionais(ObjectId estabelecimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public Task<ActionResult> Criar()
        {
            throw new NotImplementedException();
        }

        [HttpPost("{estabelecimentoId}")]
        public Task<ActionResult> Editar(ObjectId estabelecimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{estabelecimentoId}")]
        public Task<ActionResult> Remover(ObjectId estabelecimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{estabelecimentoId}/equipes")]
        public Task<ActionResult> GetEquipes(ObjectId estabelecimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{estabelecimentoId}/equipes")]
        public Task<ActionResult> CriarEquipe(ObjectId estabelecimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{estabelecimentoId}/servicos/{equipeId}")]
        public Task<ActionResult> EditarEquipe(ObjectId estabelecimentoId, ObjectId equipeId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{estabelecimentoId}/servicos/{equipeId}")]
        public Task<ActionResult> RemoverEquipe(ObjectId estabelecimentoId, ObjectId equipeId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{estabelecimentoId}/locaischamada")]
        public Task<ActionResult> GetLocaisChamada(ObjectId estabelecimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{estabelecimentoId}/locaischamada")]
        public Task<ActionResult> CriarLocalChamada(ObjectId estabelecimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{estabelecimentoId}/locaischamada/{localChamadaId}")]
        public Task<ActionResult> EditarLocalChamada(ObjectId estabelecimentoId, ObjectId localChamadaId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{estabelecimentoId}/locaischamada/{localChamadaId}/chamadas")]
        public Task<ActionResult> GetChamadas(ObjectId estabelecimentoId, ObjectId localChamadaId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{estabelecimentoId}/locaischamada/{localChamadaId}/chamar")]
        public Task<ActionResult> ChamarPaciente(ObjectId estabelecimentoId, ObjectId localChamadaId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{estabelecimentoId}/locaischamada/{localChamadaId}")]
        public Task<ActionResult> RemoverLocalChamada(ObjectId estabelecimentoId, ObjectId localChamadaId)
        {
            throw new NotImplementedException();
        }
    }
}
