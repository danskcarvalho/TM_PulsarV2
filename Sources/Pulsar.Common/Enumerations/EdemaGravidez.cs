using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum EdemaGravidez
    {
        [Display(Name = "-")]
        Menos = 1,
        [Display(Name = "+")]
        Mais = 2,
        [Display(Name = "++")]
        MaisMais = 3,
        [Display(Name = "+++")]
        MaisMaisMais = 4
    }
}
