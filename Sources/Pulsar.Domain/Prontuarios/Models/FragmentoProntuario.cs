using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Common;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.Pastas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuarios.Models
{
    public class FragmentoProntuario
    {
        public ObjectId Id { get; set; }
        public ArtefatoProntuarioTipo Tipo { get; set; }
        public ObjectId PacienteId { get; set; }
        public List<PastaArquivo> Arquivos { get; set; }
        public ObjectId? ArtefatoId { get; set; }
        public ObjectId? AtividadeId { get; set; }
        public ObjectId? ItemId { get; set; }
        public ProntuarioOrigem Origem { get; set; }
        public bool OrigemExterna { get; set; }
        /// <summary>
        /// Apenas relevante quando este fragmento tiver sido gerado à partir de uma atividade. Diz quantas vezes um procedimento foi executado.
        /// </summary>
        public int? QuantidadeProcedimentos { get; set; }
        public FinalizacaoAtividade FinalizacaoAtividade { get; set; }
        public bool AtendimentoCancelado { get; set; }
        /// <summary>
        /// Atendimento que gerou o prontuário.
        /// </summary>
        public ObjectId AtendimentoGeradorId { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
