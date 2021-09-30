using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum StatusImportacao
    {
        [Display(Name = "Pendente")]
        Pendente = 1,
        [Display(Name = "Importando")]
        Importando = 2,
        [Display(Name = "Concluída")]
        Concluida = 3,
        [Display(Name = "Concluída com erros")]
        ConcluidaComErros = 4,
        [Display(Name = "Com erros")]
        ComErros = 5
    }
}
