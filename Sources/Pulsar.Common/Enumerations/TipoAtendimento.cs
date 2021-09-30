using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum TipoAtendimento
    {
        [Display(Name = "Médico")]
        Medico = 1,
        [Display(Name = "Enfermagem")]
        Enfermagem = 2,
        [Display(Name = "Auxiliar de Enfermagem")]
        AuxiliarEnfermagem = 3,
        [Display(Name = "Realização de Procedimentos")]
        RealizacaoProcedimentos = 3,
        [Display(Name = "Vacinação")]
        Vacinacao = 5,
        [Display(Name = "Odontológico")]
        Odontologico = 6,
        [Display(Name = "Raiz")]
        Raiz = 7,
        [Display(Name = "Alteração de prontuário")]
        AlteracaoProntuario = 8,
        [Display(Name = "Múltiplos profissionais")]
        MultiplosProfissionais = 9,
        [Display(Name = "Escuta Inicial")]
        EscutaInicial = 10,
        [Display(Name = "Pré-Atendimento")]
        PreAtendimento = 11
    }
}
