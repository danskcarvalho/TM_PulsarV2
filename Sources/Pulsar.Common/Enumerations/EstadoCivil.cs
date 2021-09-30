using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum EstadoCivil
    {
        [Display(Name = "Casado")]
        Casado = 1,
        [Display(Name = "Solteiro")]
        Solteiro = 2,
        [Display(Name = "Solteiro (União Estável)")]
        SolteiroUniaoEstavel = 3,
        [Display(Name = "Seperado/Divorciado")]
        SeparadoDivorciado = 4,
        [Display(Name = "Viúvo")]
        Viuvo = 5
    }
}
