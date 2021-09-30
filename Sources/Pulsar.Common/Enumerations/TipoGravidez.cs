using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum TipoGravidez
    {
        [Display(Name = "Única")]
        Unica,
        [Display(Name = "Dupla/Gemelar")]
        DuplaGemelar,
        [Display(Name = "Tripla ou Mais")]
        TriplaOuMais,
        [Display(Name = "Ignorada")]
        Ignorada
    }
}
