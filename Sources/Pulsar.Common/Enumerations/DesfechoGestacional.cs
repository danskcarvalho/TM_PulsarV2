using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum DesfechoGestacional
    {
        [Display(Name = "Aborto")]
        Aborto = 1,
        [Display(Name = "Parto")]
        Parto = 2
    }
}
