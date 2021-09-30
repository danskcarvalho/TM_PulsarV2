using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum CategoriaAtendimento
    {
        [Display(Name = "Individual")]
        Individual,
        [Display(Name = "Retroativo")]
        Retroativo,
        [Display(Name = "Domiciliar")]
        Domiciliar
    }
}
