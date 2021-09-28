using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum CondutaAtendimentoOdontologico
    {
        [Display(Name = "Retorno para consulta agendada")]
        RetornoConsultaAgendada = 16,
        [Display(Name = "Agendamento para outros profissionais AB")]
        AgendamentoOutrosProfissionaisAB = 12,
        [Display(Name = "Agendamento para NASF")]
        AgendamentoNASF = 13,
        [Display(Name = "Agendamento para grupos")]
        AgendamentoGrupos = 14,
        [Display(Name = "Tratamento concluído")]
        TratamentoConcluido = 15,
        [Display(Name = "Alta do episódio")]
        AltaEpisodio = 17,
        [Display(Name = "Atendimento à pacientes com necessidades especiais")]
        AtendimentoPacientesNecessidadesEspeciais = 1,
        [Display(Name = "Cirurgia BMF")]
        CirurgiaBMF = 2,
        [Display(Name = "Endodontia")]
        Endodontia = 3,
        [Display(Name = "Estomatologia")]
        Estomatologia = 4,
        [Display(Name = "Implantodontia")]
        Implantodontia = 5,
        [Display(Name = "Odontopediatria")]
        Odontopediatria = 6,
        [Display(Name = "Ortodontia / Ortopedia")]
        OrtodontiaOrtopedia = 7,
        [Display(Name = "Periodontia")]
        Periodontia = 8,
        [Display(Name = "Prótese dentária")]
        ProteseDentaria = 9,
        [Display(Name = "Radiologia")]
        Radiologia = 10,
        [Display(Name = "Outros")]
        Outros = 11
    }
}
