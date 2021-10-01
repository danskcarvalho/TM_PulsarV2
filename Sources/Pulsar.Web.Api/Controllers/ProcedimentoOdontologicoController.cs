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
    [Route("v2/procedimentosodontologicos")]
    [Authorize]
    public class ProcedimentoOdontologicoController : PulsarController
    {
        public ProcedimentoOdontologicoController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
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

        [HttpPost("{procOdontologicoId}")]
        public Task<ActionResult> Editar(ObjectId procOdontologicoId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{procOdontologicoId}")]
        public Task<ActionResult> Remover(ObjectId procOdontologicoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{procOdontologicoId}/finalizar")]
        public Task<ActionResult> Finalizar(ObjectId procOdontologicoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{procOdontologicoId}/reabrir")]
        public Task<ActionResult> Reabrir(ObjectId procOdontologicoId)
        {
            throw new NotImplementedException();
        }
    }
}
