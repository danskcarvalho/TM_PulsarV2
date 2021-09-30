using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum GlicemiaMomentoColeta
    {
        [Display(Name = "Jejum")]
        Jejum = 1,
        [Display(Name = "Pré-Prandial")]
        PrePrandial = 2,
        [Display(Name = "Pós-Prandial")]
        PosPrandial = 3,
        [Display(Name = "Não Especificado")]
        NaoEspecificado = 4
    }
}
