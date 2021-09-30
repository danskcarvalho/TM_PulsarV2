using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum CriticidadeAlergia
    {
        [Display(Name = "Baixa")]
        Baixa = 1,
        [Display(Name = "Alta")]
        Alta = 2
    }
}
