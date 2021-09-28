using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum VigilanciaSaudeBucal
    {
        [Display(Name = "Abscesso dento alveolar")]
        AbscessoDentoAlveolar = 1,
        [Display(Name = "Alteração em tecidos moles")]
        AlteracaoTecidosMoles = 2,
        [Display(Name = "Dor de dente")]
        DorDente = 3,
        [Display(Name = "Fendas / Fissuras lábio palatais")]
        FendasFissurasLabioPalatais = 4,
        [Display(Name = "Fluorose dentária moderada / severa")]
        FluoroseDentariaModeradaSevera = 5,
        [Display(Name = "Traumatismo dento alveolar")]
        TraumatismoDentoAlveolar = 6,
        [Display(Name = "Não identificado")]
        NaoIdentificado = 99
    }
}
