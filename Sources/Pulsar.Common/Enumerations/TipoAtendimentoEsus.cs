using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum TipoAtendimentoEsus
    {
        [Display(Name = "Consulta agendada programada / Cuidado continuado")]
        ConsultaAgendadaProgramadaCuidadoContinuado = 1,
        [Display(Name = "Consulta agendada")]
        ConsultaAgendada = 2,
        [Display(Name = "Escuta inicial / Orientação")]
        EscutaInicialOrientação = 4,
        [Display(Name = "Consulta no dia")]
        ConsultaDia = 5,
        [Display(Name = "Atendimento de urgência")]
        AtendimentoUrgência = 6,
        [Display(Name = "Atendimento programado")]
        AtendimentoProgramado = 7,
        [Display(Name = "Atendimento não programado")]
        AtendimentoNaoProgramado = 8,
        [Display(Name = "Visita domiciliar pós-óbito")]
        VisitaDomiciliarPosObito = 9
    }
}
