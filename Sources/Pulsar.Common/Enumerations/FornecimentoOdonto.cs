using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum FornecimentoOdonto
    {
        [Display(Name = "Escova dental")]
        EscovaDental = 1,
        [Display(Name = "Creme dental")]
        CremeDental = 2,
        [Display(Name = "Fio dental")]
        FioDental = 3
    }
}
