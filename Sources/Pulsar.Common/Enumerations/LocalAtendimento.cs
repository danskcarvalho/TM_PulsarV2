using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum LocalAtendimento
    {
        [Display(Name = "UBS")]
        Ubs = 1,
        [Display(Name = "Unidade móvel")]
        UnidadeMovel = 2,
        [Display(Name = "Rua")]
        Rua = 3,
        [Display(Name = "Domicílio")]
        Domicilio = 4,
        [Display(Name = "Escola / Creche")]
        EscolaCreche = 5,
        [Display(Name = "Outros")]
        Outros = 6,
        [Display(Name = "Polo (academia da saúde)")]
        PoloAcademiaSaude = 7,
        [Display(Name = "Instituição / Abrigo")]
        InstituicaoAbrigo = 8,
        [Display(Name = "Unidade prisional ou congêneres")]
        UnidadePrisionalCongeneres = 9,
        [Display(Name = "Unidade socioeducativa")]
        UnidadeSocioeducativa = 10,
        [Display(Name = "Hospital")]
        Hospital = 11,
        [Display(Name = "Unidade de pronto atendimento")]
        UnidadeProntoAtendimento = 12,
        [Display(Name = "CACON / UNACON")]
        CaconUnacon = 13
    }
}
