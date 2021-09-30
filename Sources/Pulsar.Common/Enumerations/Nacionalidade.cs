using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum Nacionalidade
    {
        [Display(Name = "Brasileira")]
        Brasileira = 1,
        [Display(Name = "Naturalizado")]
        Naturalizado = 2,
        [Display(Name = "Estrangeiro")]
        Estrangeiro = 3
    }
}
