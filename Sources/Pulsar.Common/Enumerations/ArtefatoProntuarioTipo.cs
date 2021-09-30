using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum ArtefatoProntuarioTipo
    {
        [Display(Name = "Medicamento")]
        Medicamento,
        [Display(Name = "Prescrição de Medicamentos")]
        PrescricaoMedicamentos,
        [Display(Name = "Exame")]
        Exame,
        [Display(Name = "Prescrição de Exames")]
        PrescricaoExames,
        [Display(Name = "Vacinação")]
        Vacinacao,
        [Display(Name = "Alergia")]
        Alergia,
        [Display(Name = "Condição de Saúde")]
        CondicaoSaude,
        [Display(Name = "Relatório Médico")]
        RelatorioMedico,
        [Display(Name = "Antecedentes Pessoais")]
        AntecedentesPessoais,
        [Display(Name = "Antecedentes Familiares")]
        AntecedentesFamiliares
    }
}
