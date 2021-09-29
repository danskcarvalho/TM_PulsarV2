using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class ArtefatoAtendimentoResumido
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
        public AtendimentoResumido AtendimentoGerador { get; set; }
    }
}
