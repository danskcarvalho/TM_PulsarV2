using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum NivelDeficienciaMental
    {
        [Display(Name = "Leve")]
        Leve,
        [Display(Name = "Moderado")]
        Moderado,
        [Display(Name = "Grave")]
        Grave,
        [Display(Name = "Profundo")]
        Profundo
    }
}
