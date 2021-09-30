using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum RacaCor
    {
        [Display(Name = "Branca")]
        Branca = 1,
        [Display(Name = "Preta")]
        Preta = 2,
        [Display(Name = "Parda")]
        Parda = 3,
        [Display(Name = "Amarela")]
        Amarela = 4,
        [Display(Name = "Índigena")]
        Indigena = 5,
        [Display(Name = "Sem Informação")]
        SemInformacao = 6,
    }
}
