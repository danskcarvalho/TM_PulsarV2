using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum ProblemaCoroaDente
    {
        [Display(Name = "Prótese Parcial Removível")]
        ProteseParcialRemovivel = 1,
        [Display(Name = "Prótese Coronária Unitária")]
        ProteseCoronariaUnitaria = 2,
        [Display(Name = "Prótese Temporária")]
        ProteseTemporaria = 3,
        [Display(Name = "Ausente")]
        Ausente = 4,
        [Display(Name = "Cálculo Dental")]
        CalculoDental = 5,
        [Display(Name = "Cariado")]
        Cariado = 6,
        [Display(Name = "Coroa")]
        Coroa = 7,
        [Display(Name = "Extração Indicada")]
        ExtracaoIndicada = 8,
        [Display(Name = "Extraído")]
        Extraido = 9,
        [Display(Name = "Fratura")]
        Fratura = 10,
        [Display(Name = "Hígido")]
        Higido = 11,
        [Display(Name = "Hígido Selado")]
        HigidoSelado = 12,
        [Display(Name = "Incluso")]
        Incluso = 13,
        [Display(Name = "Mancha Branca Ativa")]
        ManchaBrancaAtiva = 14,
        [Display(Name = "Pilar")]
        Pilar = 15,
        [Display(Name = "Restaurado")]
        Restaurado = 16,
        [Display(Name = "Restaurado/Cária")]
        RestauradoCarie = 17,
        [Display(Name = "Resto Radicular")]
        RestoRadicular = 18,
        [Display(Name = "Retração Gengival")]
        RetracaoGengival = 19,
        [Display(Name = "Selante Indicado")]
        SelanteIndicado = 20
    }
}
