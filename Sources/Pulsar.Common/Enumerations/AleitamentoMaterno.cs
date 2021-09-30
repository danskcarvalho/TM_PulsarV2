using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum AleitamentoMaterno 
    {
        [Display(Name = "Exclusivo")]
        Exclusivo = 1,
        [Display(Name = "Predominante")]
        Predominante = 2,
        [Display(Name = "Complementado")]
        Complementado = 3,
        [Display(Name = "Inexistente")]
        Inexistente = 4
    }
}
