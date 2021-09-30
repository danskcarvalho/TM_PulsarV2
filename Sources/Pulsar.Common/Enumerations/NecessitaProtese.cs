using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum NecessitaProtese
    {
        [Display(Name = "Inferior")]
        Inferior = 1,
        [Display(Name = "Superior")]
        Superior = 2,
        [Display(Name = "Parcial")]
        Parcial = 3
    }
}
