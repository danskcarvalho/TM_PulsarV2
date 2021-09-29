using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtividadeResumida
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
        public AtendimentoResumido AtendimentoGerador { get; set; }
        public string Observacoes { get; set; }
        public TipoAtividade Tipo { get; set; }
        public int Quantidade { get; set; }
        public FinalizacaoAtividade Finalizacao { get; set; }
    }
}
