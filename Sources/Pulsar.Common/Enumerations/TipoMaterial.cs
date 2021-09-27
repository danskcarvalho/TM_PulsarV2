using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum TipoMaterial
    {
        [Display(Name = "Medicamento")]
        Medicamento = 1,
        [Display(Name = "Vacina")]
        Vacina = 2
    }
}
