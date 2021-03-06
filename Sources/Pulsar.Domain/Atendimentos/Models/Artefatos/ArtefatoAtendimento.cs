using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Common;
using Pulsar.Domain.Pastas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class ArtefatoAtendimento
    {
        public ObjectId Id { get; set; }
        public ArtefatoAtendimentoTipo Tipo { get; set; }
        // <summary>
        /// Utilizado para mostrar uma breve descrição da atividade (linha 1).
        /// </summary>
        public string NomeDescricao { get; set; }
        /// <summary>
        /// Utilizado para mostrar uma breve descrição da atividade (linha 2).
        /// </summary>
        public string NomeDetalhes { get; set; }
        public ObjectId AtendimentoGeradorId { get; set; }
        public List<PastaArquivo> Arquivos { get; set; }
        public bool OrigemExterna { get; set; }
        public ObjectId? ProntuarioId { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
