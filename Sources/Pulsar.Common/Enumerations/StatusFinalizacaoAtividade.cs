using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum StatusFinalizacaoAtividade
    {
        [Display(Name = "Realizada")]
        Realizada = 1,
        [Display(Name = "Não Realizada")]
        NaoRealizada = 2,
        [Display(Name = "Parcialmente Realizada")]
        ParcialmenteRealizada = 3
    }
}
