using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Common.Exceptions;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Acompanhamentos.Models
{
    public class Acompanhamento
    {
        public ObjectId Id { get; set; }
        public AcompanhamentoTipo Tipo { get; set; }
        public StatusAcompanhamento Status { get; set; }
        public ObjectId PacienteId { get; set; }
        public List<ObjectId> AtendimentosIds { get; set; }
        public DateTime? DataPrimeiraAbertura { get; set; }
        public DateTime? DataUltimaFinalizacao { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }

        public virtual async Task Entrar(ObjectId usuarioId, AtendimentoComProfissional atendimento, Container container)
        {
            if (Status != StatusAcompanhamento.Aberto)
                throw new PulsarException(PulsarErrorCode.BadRequest, "O acompanhamento já foi finalizado.");

            AtendimentosIds.Add(atendimento.Id);
            DataRegistro.Atualizado(usuarioId);
            DataVersion++;
            await container.Acompanhamentos.UpdateOne(this);
        }
    }
}
