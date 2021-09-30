using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum CategoriaMotivoProblema
    {
        [Display(Name = "Diagnóstico/Enfermidade")]
        DiagnosticoEnfermidade = 1,
        [Display(Name = "Deficiência, incapacidade")]
        DeficienciaIncapacidade = 2,
        [Display(Name = "Sintoma")]
        Sintoma = 3,
        [Display(Name = "Sinal")]
        Sinal = 4,
        [Display(Name = "Exame complementar anormal")]
        ExameComplementarAnormal = 5,
        [Display(Name = "Alergia, efeito adverso de um fármaco")]
        AlergiaEfeitoAdversoFarmaco = 6,
        [Display(Name = "Intervenção cirúrgica")]
        IntervencaoCirurgica = 7,
        [Display(Name = "Síndrome")]
        Sindrome = 8,
        [Display(Name = "Efeitos de traumatismos")]
        EfeitosTraumatismos = 9,
        [Display(Name = "Fator de risco")]
        FatorRisco = 10,
        [Display(Name = "Transtorno psicológico ou psiquiátrico")]
        TranstornoPsicologicoPsiquiatrico = 11,
        [Display(Name = "Alteração da dinâmica familiar, social ou laboral")]
        AlteracaoDinamicaFamiliarSocialLaboral = 12
    }
}
