using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum TipoMedicamento
    {
        [Display(Name = "Comum")]
        Comum = 0,
        [Display(Name = "Especial")]
        Especial = 1,
        [Display(Name = "Especial - notificação branca")]
        EspecialBranca = 2,
        [Display(Name = "Especial - notificação azul")]
        EspecialAzul = 3,
        [Display(Name = "Especial - notificação amarela")]
        EspecialAmarela = 4
    }
}
