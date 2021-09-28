using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum Turno
    {
        [Display(Name = "Manhã")]
        Manha = 1,
        [Display(Name = "Tarde")]
        Tarde = 2,
        [Display(Name = "Noite")]
        Noite = 3
    }
}
