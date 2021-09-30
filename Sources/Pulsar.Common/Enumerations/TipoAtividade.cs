using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum TipoAtividade
    {
        [Display(Name = "Administrar Medicamento")]
        Medicamento,
        [Display(Name = "Realizar Procedimento")]
        Procedimento,
        [Display(Name = "Aplicar Vacina")]
        Vacinacao
    }
}
