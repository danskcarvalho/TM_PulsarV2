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
    [Route("v2/atendimentos")]
    [Authorize]
    public class AtendimentoController : PulsarController
    {
        public AtendimentoController(IConfiguration configuration, ICommandBus commandBus, IRequestBus requestBus) : base(configuration, commandBus, requestBus)
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

        [HttpPost("{atendimentoId}")]
        public Task<ActionResult> Salvar(ObjectId atendimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{atendimentoId}/acompanhar")]
        public Task<ActionResult> Acompanhar(ObjectId atendimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{atendimentoId}/retomar")]
        public Task<ActionResult> Retomar(ObjectId atendimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{atendimentoId}/finalizar")]
        public Task<ActionResult> Finalizar(ObjectId atendimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{atendimentoId}/reabrir")]
        public Task<ActionResult> Reabrir(ObjectId atendimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{atendimentoId}/retornar")]
        public Task<ActionResult> RetornarFilaAtendimento(ObjectId atendimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{atendimentoId}/transferir")]
        public Task<ActionResult> Transferir(ObjectId atendimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{atendimentoId}")]
        public Task<ActionResult> Cancelar(ObjectId atendimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{atendimentoId}/atividades")]
        public Task<ActionResult> GetAtividades(ObjectId atendimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{atendimentoId}/atividades")]
        public Task<ActionResult> CriarAtividade(ObjectId atendimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{atendimentoId}/atividades/{atividadeId}")]
        public Task<ActionResult> RemoverAtividade(ObjectId atendimentoId, ObjectId atividadeId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{atendimentoId}/atividades/{atividadeId}/finalizar")]
        public Task<ActionResult> FinalizarAtividade(ObjectId atendimentoId, ObjectId atividadeId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{atendimentoId}/atividades/{atividadeId}/reabrir")]
        public Task<ActionResult> ReabrirAtividade(ObjectId atendimentoId, ObjectId atividadeId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{atendimentoId}/artefatos")]
        public Task<ActionResult> GetArtefatos(ObjectId atendimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{atendimentoId}/examesavaliados")]
        public Task<ActionResult> GetExamesAvaliados(ObjectId atendimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{atendimentoId}/artefatos")]
        public Task<ActionResult> CriarArtefato(ObjectId atendimentoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{atendimentoId}/artefatos/{artefatoId}")]
        public Task<ActionResult> EditarArtefato(ObjectId atendimentoId, ObjectId artefatoId)
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{atendimentoId}/artefatos/{artefatoId}")]
        public Task<ActionResult> RemoverArtefato(ObjectId atendimentoId, ObjectId artefatoId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{atendimentoId}/artefatos/{artefatoId}/resultado")]
        public Task<ActionResult> InformarResultado(ObjectId atendimentoId, ObjectId artefatoId)
        {
            throw new NotImplementedException();
        }
    }
}
