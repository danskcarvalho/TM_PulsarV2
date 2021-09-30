using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum EncaminhamentoRisco
    {
        [Display(Name = "Rotina")]
        Rotina = 1,
        [Display(Name = "Baixa")]
        Baixa = 2,
        [Display(Name = "Média")]
        Media = 3,
        [Display(Name = "Alta")]
        Alta = 4
    }
}
