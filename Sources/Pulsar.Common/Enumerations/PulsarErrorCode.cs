using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum PulsarErrorCode
    {
        [Display(Name = "Sistema indisponível no momento devido a uma quantidade alta de acessos simultâneos. Por favor, tente a operação novamente mais tarde.")]
        TooBusy = 1,
        [Display(Name = "Sem permissões para realizar a operação solicitada.")]
        Forbidden = 2,
        [Display(Name = "Erro interno do servidor.")]
        Unknown = 999999999
    }
}
