using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum LocalProcedimentoOdontologico
    {
        [Display(Name = "Dente")]
        Dente = 1,
        [Display(Name = "Sextante")]
        Sextante = 2,
        [Display(Name = "Arcada")]
        Arcada = 3,
        [Display(Name = "Outros")]
        Outros = 4
    }
}
