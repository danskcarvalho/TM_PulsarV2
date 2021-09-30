using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum ExameFisicoPuericultura
    {
        [Display(Name = "Eutrofia")]
        Eutrofia = 1,
        [Display(Name = "Distrofia")]
        Distrofia = 2,
        [Display(Name = "Normal")]
        Normal = 3,
        [Display(Name = "Baixa Estatura")]
        BaixaEstatura = 4,
        [Display(Name = "Adequado")]
        Adequado = 5,
        [Display(Name = "Inadequado")]
        Inadequado = 6,
        [Display(Name = "Completa")]
        Completa = 7,
        [Display(Name = "Incompleta")]
        Incompleta = 8,
        [Display(Name = "Alto Risco")]
        AltoRisco = 9,
        [Display(Name = "Baixo Risco")]
        BaixoRisco = 10
    }
}
