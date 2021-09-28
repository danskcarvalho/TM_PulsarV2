using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum CondutaAtendimentoIndividual
    {
        [Display(Name = "Retorno para consulta agendada")]
        RetornoConsultaAgendada = 1,
        [Display(Name = "Retorno para cuidado continuado / programado")]
        RetornoCuidadoContinuadoProgramado = 2,
        [Display(Name = "Agendamento para grupos")]
        AgendamentoGrupos = 12,
        [Display(Name = "Agendamento para NASF")]
        AgendamentoNASF = 3,
        [Display(Name = "Alta do episódio")]
        AltaEpisodio = 9,
        [Display(Name = "Encaminhamento interno no dia")]
        EncaminhamentoInternoDia = 11,
        [Display(Name = "Encaminhamento para serviço especializado")]
        EncaminhamentoServicoEspecializado = 4,
        [Display(Name = "Encaminhamento para CAPS")]
        EncaminhamentoCAPS = 5,
        [Display(Name = "Encaminhamento para internação hospitalar")]
        EncaminhamentoInternacaoHospitalar = 6,
        [Display(Name = "Encaminhamento para urgência")]
        EncaminhamentoUrgencia = 7,
        [Display(Name = "Encaminhamento para serviço de atenção domiciliar")]
        EncaminhamentoParaServicoAtencaoDomiciliar = 8,
        [Display(Name = "Encaminhamento intersetorial")]
        EncaminhamentoIntersetorial = 10
    }
}
