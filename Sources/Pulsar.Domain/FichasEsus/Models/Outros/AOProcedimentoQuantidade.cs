using Pulsar.Domain.Procedimentos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pulsar.Domain.FichasEsus.Models
{
    public class AOProcedimentoQuantidade
    {
        public ProcedimentoResumido Procedimento { get; set; }
        public int? Quantidade { get; set; }
    }
}
