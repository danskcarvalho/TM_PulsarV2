using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum FichaTipo
    {
        [Display(Name = "Atendimento Individual")]
        AtendimentoIndividual = 1,
        [Display(Name = "Procedimentos")]
        Procedimentos = 2,
        [Display(Name = "Vacinação")]
        Vacinacao = 3,
        [Display(Name = "Odontológico")]
        Odontologico = 4
    }
}
