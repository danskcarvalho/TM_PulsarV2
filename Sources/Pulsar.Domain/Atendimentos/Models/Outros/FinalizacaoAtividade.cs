﻿using Pulsar.Common.Enumerations;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class FinalizacaoAtividade
    {
        public int QuantidadeRealizada { get; set; }
        public int QuantidadeNaoRealizada { get; set; }
        public StatusFinalizacaoAtividade Status { get; set; }
        public AtendimentoResumido AtendimentoExecutor { get; set; }
        public string Observacoes { get; set; }
        public TimeSpan? Horario { get; set; }
        public TimeSpan? Duracao { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
    }
}