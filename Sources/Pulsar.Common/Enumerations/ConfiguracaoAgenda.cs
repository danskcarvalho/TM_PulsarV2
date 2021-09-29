using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum ConfiguracaoAgenda
    {
        [Display(Name = "Por Profissional")]
        PorProfissional = 1,
        [Display(Name = "Por Equipe")]
        PorEquipe = 2
    }
}
