using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum StatusAtendimento
    {
        [Display(Name = "Aberto")]
        Aberto = 1,
        [Display(Name = "Aguardando Retorno")]
        AguardandoRetorno = 2,
        [Display(Name = "Finalizado")]
        Finalizado = 3,
        [Display(Name = "Cancelado")]
        Cancelado = 4,
        [Display(Name = "Aguardando")]
        Aguardando = 5
    }
}
