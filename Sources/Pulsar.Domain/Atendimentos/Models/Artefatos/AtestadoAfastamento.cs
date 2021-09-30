﻿using Pulsar.Domain.Diagnosticos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtestadoAfastamento : ArtefatoAtendimento
    {
        public AtestadoAfastamento()
        {
            this.Tipo = Common.Enumerations.ArtefatoAtendimentoTipo.AtestadoAfastamento;
        }

        public  int? DiasRepouso { get; set; }
        public  List<DiagnosticoResumido> CID10 { get; set; }
        public  string Descricao { get; set; }
    }
}