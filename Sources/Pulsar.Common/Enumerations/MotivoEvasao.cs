using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum MotivoEvasao
    {
        [Display(Name = "Desistência")]
        Desistencia = 1,
        [Display(Name = "Desaparecimento")]
        Desaparecimento = 2,
        [Display(Name = "Intercorrências")]
        Intercorrencias = 3
    }
}
