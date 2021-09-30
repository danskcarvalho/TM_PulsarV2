using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum LocalTipo
    {
        [Display(Name = "País")]
        Pais = 1,
        [Display(Name = "Estado")]
        Estado = 2,
        [Display(Name = "Município")]
        Municipio = 3
    }
}
