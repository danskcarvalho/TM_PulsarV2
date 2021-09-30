using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum CategoriaAlergia
    {
        [Display(Name = "Alimento")]
        Alimento = 1,
        [Display(Name = "Animal")]
        Animal = 2,
        [Display(Name = "Ingrediente não ativo do medicamento")]
        IngredienteNaoAtivo = 3,
        [Display(Name = "Fármaco(s) presente(s) no medicamento ou constraste radiológico")]
        FarmacoPresente = 4,
        [Display(Name = "Outras substâncias ou produtos químicos")]
        OutrasSubstancias = 5,
        [Display(Name = "Produto ambiental")]
        ProdutoAmbiental = 6,
        [Display(Name = "Outros")]
        Outros = 7
    }
}
