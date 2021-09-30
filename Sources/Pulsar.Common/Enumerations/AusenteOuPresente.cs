using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum AusenteOuPresente
    {
        [Display(Name = "Ausente")]
        Ausente = 1,
        [Display(Name = "Presente")]
        Presente = 2
    }
}
