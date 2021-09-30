using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum StatusCondicaoSaude
    {
        [Display(Name = "Ativa")]
        Ativa = 1,
        [Display(Name = "Resolvida")]
        Resolvida = 2,
        [Display(Name = "Latente")]
        Latente = 3
    }
}
