using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum RacionalidadeSaude
    {
        [Display(Name = "Medicina Tradicional Chinesa")]
        MedicinaTradicionalChinesa = 1,
        [Display(Name = "Antroposofia aplicada à saúde")]
        AntroposofiaAplicadaSaude = 2,
        [Display(Name = "Homeopatia")]
        Homeopatia = 3,
        [Display(Name = "Fitoterapia")]
        Fitoterapia = 4,
        [Display(Name = "Ayurveda")]
        Ayurveda = 5,
        [Display(Name = "Outra")]
        Outra = 6
    }
}
