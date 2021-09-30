using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum RiscoGravidez
    {
        [Display(Name = "Alto")]
        Alto = 1,
        [Display(Name = "Baixo")]
        Baixo = 2
    }
}
