using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pulsar.Domain.FichasEsus.Models
{
    public class AIExame
    {
        public virtual ProcedimentoResumido Procedimento { get; set; }
        public virtual bool? Solicitado { get; set; }
        public virtual bool? Avaliado { get; set; }
    }
}
