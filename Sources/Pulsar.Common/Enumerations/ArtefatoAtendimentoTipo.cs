using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum ArtefatoAtendimentoTipo
    {
        [Display(Name = "Prescrição de Medicamentos")]
        PrescricaoMedicamentos,
        [Display(Name = "Prescrição de Exames")]
        PrescricaoExames,
        [Display(Name = "Prescrição de Procedimentos")]
        PrescricaoProcedimentos,
        [Display(Name = "Atestado de Afastamento")]
        AtestadoAfastamento,
        [Display(Name = "Atestado de Comparecimento")]
        AtestadoComparecimento,
        [Display(Name = "Guia de Encaminhamentos")]
        GuiaEncaminhamentos,
        [Display(Name = "Vacinação")]
        Vacinacao
    }
}
