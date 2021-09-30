using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Comum;
using Pulsar.Domain.Pastas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuario.Models
{
    public class ProntuarioDados
    {
        public ObjectId ProntuarioId { get; set; }
        public ArtefatoProntuarioTipo Tipo { get; set; }
        public ObjectId DadoId { get; set; }
        /// <summary>
        /// Atendimento que gerou ou modificou o prontuário.
        /// </summary>
        public AtendimentoResumido AtendimentoGerador { get; set; }
        public List<PastaArquivo> Arquivos { get; set; }
        public ObjectId? ArtefatoId { get; set; }
        public ObjectId? AtividadeId { get; set; }
        public ObjectId? ItemId { get; set; }
        public ProntuarioOrigem Origem { get; set; }
        public bool OrigemExterna { get; set; }
        public DataRegistro DataRegistro { get; set; }
    }
}
