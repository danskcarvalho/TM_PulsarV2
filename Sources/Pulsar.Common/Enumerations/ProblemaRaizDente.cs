using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum ProblemaRaizDente
    {
        [Display(Name = "Cárie/Raiz")]
        CarieRaiz = 1,
        [Display(Name = "Endodontia")]
        Endodontia = 2,
        [Display(Name = "Implante")]
        Implante = 3,
        [Display(Name = "Núcleo")]
        Nucleo = 4
    }
}
