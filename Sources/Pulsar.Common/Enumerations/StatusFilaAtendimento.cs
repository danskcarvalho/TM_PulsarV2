using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum StatusFilaAtendimento
    {
        [Display(Name = "Aberta")]
        Aberta = 1,
        [Display(Name = "Fechada")]
        Fechada = 2
    }
}
