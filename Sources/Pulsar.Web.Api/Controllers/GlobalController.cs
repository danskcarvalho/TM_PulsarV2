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
    [Route("v2")]
    [Authorize]
    public class GlobalController : PulsarController
    {
        public GlobalController(IConfiguration configuration,
                                   ICommandBus commandBus,
                                   IRequestBus requestBus) : base(configuration, commandBus, requestBus)
        {
        }

        [HttpGet("constantes/tipos")]
        public Task<ActionResult> GetConstantesTipos()
        {
            throw new NotImplementedException();
        }

        [HttpGet("constantes")]
        public Task<ActionResult> GetConstantes()
        {
            throw new NotImplementedException();
        }

        [HttpGet("condicoessaude/chaves")]
        public Task<ActionResult> GetChavesCondicaoSaude()
        {
            throw new NotImplementedException();
        }

        [HttpGet("dentes")]
        public Task<ActionResult> GetDentes()
        {
            throw new NotImplementedException();
        }

        [HttpGet("diagnosticos")]
        public Task<ActionResult> GetDiagnosticos()
        {
            throw new NotImplementedException();
        }

        [HttpGet("especialidades")]
        public Task<ActionResult> GetEspecialidades()
        {
            throw new NotImplementedException();
        }

        [HttpGet("etnias")]
        public Task<ActionResult> GetEtnias()
        {
            throw new NotImplementedException();
        }

        [HttpGet("ineps")]
        public Task<ActionResult> GetIneps()
        {
            throw new NotImplementedException();
        }

        [HttpGet("materiais")]
        public Task<ActionResult> GetMateriais()
        {
            throw new NotImplementedException();
        }

        [HttpGet("principiosativos")]
        public Task<ActionResult> GetPrincipiosAtivos()
        {
            throw new NotImplementedException();
        }

        [HttpGet("procedimentos")]
        public Task<ActionResult> GetProcedimentos()
        {
            throw new NotImplementedException();
        }

        [HttpGet("regioes")]
        public Task<ActionResult> GetRegioes()
        {
            throw new NotImplementedException();
        }
    }
}
