using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum Arcada
    {
        [Display(Name = "Superior (Maxilar)")]
        Superior = 1,
        [Display(Name = "Inferior (Mandibular)")]
        Inferior = 2
    }
}
