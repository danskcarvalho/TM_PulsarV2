using Pulsar.Common.Enumerations;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Servicos.Models
{
    public class ServicoTipoAtendimento
    {
        public TipoAtendimento TipoAtendimento { get; set; }
        public ProcedimentoResumido Procedimento { get; set; }
    }
}
