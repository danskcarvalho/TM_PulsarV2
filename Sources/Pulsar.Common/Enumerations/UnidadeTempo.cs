using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum UnidadeTempo
    {
        [Display(Name = "Segundos")]
        Segundos = 1,
        [Display(Name = "Minutos")]
        Minutos = 2,
        [Display(Name = "Horas")]
        Horas = 3,
        [Display(Name = "Dias")]
        Dias = 4,
        [Display(Name = "Semanas")]
        Semanas = 5,
        [Display(Name = "Meses")]
        Meses = 6,
        [Display(Name = "Anos")]
        Anos = 7
    }
}
