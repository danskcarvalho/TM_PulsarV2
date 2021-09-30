using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    /// <summary>
    /// Seguindo o padrão do LEDI.
    /// </summary>
    public enum RiscoAtendimento
    {
        [Display(Name = "Emergência")]
        Emergencia = 3,
        [Display(Name = "Urgência")]
        Urgencia = 2,
        [Display(Name = "Prioritário")]
        Prioritario = 1,
        [Display(Name = "Não Informado")]
        NaoInformado = 0
    }
}
