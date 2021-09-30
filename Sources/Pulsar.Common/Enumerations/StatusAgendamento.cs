using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum StatusAgendamento
    {
        [Display(Name = "Pré-Agendado")]
        PreAgendado = 1,
        [Display(Name = "Agendado")]
        Agendado = 2,
        [Display(Name = "Aguardando Atendimento")]
        AguardandoAtendimento = 3,
        [Display(Name = "Cancelado")]
        Cancelado = 4,
        [Display(Name = "Atendido")]
        Atendido = 5,
        [Display(Name = "Desistência")]
        Desistencia = 6
    }
}
