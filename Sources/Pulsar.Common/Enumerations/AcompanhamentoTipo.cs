using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum AcompanhamentoTipo
    {
        [Display(Name = "Pré-Natal")]
        PreNatal = 1,
        [Display(Name = "Puericultura")]
        Puericultura = 2
    }
}
