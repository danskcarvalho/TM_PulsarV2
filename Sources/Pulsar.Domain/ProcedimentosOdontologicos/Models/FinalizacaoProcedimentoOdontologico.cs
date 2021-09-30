using Pulsar.Common.Enumerations;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.ProcedimentosOdontologicos.Models
{
    public class FinalizacaoProcedimentoOdontologico
    {
        public StatusFinalizacaoAtividade Status { get; set; }
        public AtendimentoResumido AtendimentoExecutor { get; set; }
        public string Observacoes { get; set; }
        public TimeSpan? Horario { get; set; }
        public TimeSpan? Duracao { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
    }
}
