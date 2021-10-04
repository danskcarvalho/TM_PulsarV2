using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Common;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class Atividade
    {
        public ObjectId AtividadeId { get; set; }
        /// <summary>
        /// Utilizado para mostrar uma breve descrição da atividade (linha 1).
        /// </summary>
        public string NomeDescricao { get; set; }
        /// <summary>
        /// Utilizado para mostrar uma breve descrição da atividade (linha 2).
        /// </summary>
        public string NomeDetalhes { get; set; }
        public ObjectId? ProntuarioId { get; set; }
        public ObjectId AtendimentoGeradorId { get; set; }
        public string Observacoes { get; set; }
        public TipoAtividade Tipo { get; set; }
        public int? Quantidade { get; set; }
        /// <summary>
        /// Apenas faz sentido quando a quantidade é informado. Ex.: o procedimento deve ser realizado de 20 em 20min.
        /// </summary>
        public TimeSpan? FrequenciaRealizacao { get; set; }
        public FinalizacaoAtividade Finalizacao { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
