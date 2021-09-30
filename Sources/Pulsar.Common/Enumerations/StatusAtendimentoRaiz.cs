using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum StatusAtendimentoRaiz
    {
        [Display(Name = "Aberto")]
        Aberto = 1,
        [Display(Name = "Finalizado")]
        Finalizado = 2
    }
}
