using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum TipoAtendimentoEvento
    {
        [Display(Name = "Atendimento Aberto")]
        AtendimentoAberto,
        [Display(Name = "Atendimento Finalizado")]
        AtendimentoFinalizado,
        [Display(Name = "Aendimento Interrompido")]
        AtendimentoInterrompido,
        [Display(Name = "Atendimento Retomado")]
        AtendimentoRetomado,
        [Display(Name = "Atividade Concluída")]
        AtividadeConcluida,
        [Display(Name = "Atividade Não Realizada")]
        AtividadeNaoRealizada,
        [Display(Name = "Atividade Reiniciada")]
        AtividadeReiniciada,
        [Display(Name = "Registro de Evasão")]
        RegistroEvasao
    }
}
