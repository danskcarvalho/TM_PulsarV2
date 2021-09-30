using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum Sexo
    {
        [Display(Name = "Masculino")]
        Masculino = 0,
        [Display(Name = "Feminino")]
        Feminino = 1
    }
}
