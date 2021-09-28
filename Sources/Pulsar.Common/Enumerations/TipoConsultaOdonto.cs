using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum TipoConsultaOdonto
    {
        [Display(Name = "Primeira consulta odontológica programática")]
        PrimeiraConsultaOdontologicaProgramatica = 1,
        [Display(Name = "Consulta de retorno em odontologia")]
        ConsultaRetornoOdontologia = 2,
        [Display(Name = "Consulta de manutenção em odontologia")]
        ConsultaManutencaoOdontologia = 4
    }
}
