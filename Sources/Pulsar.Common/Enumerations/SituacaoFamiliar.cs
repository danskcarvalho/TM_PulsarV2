using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum SituacaoFamiliar
    {
        [Display(Name = "Convive com companheiro e filho(s)")]
        ConviveComCompanheiroFilho = 1,
        [Display(Name = "Convive com companheiro com laços conjugais e sem filhos")]
        ConviveComCompanheiroLacosConjugaisSemFilhos = 2,
        [Display(Name = "Convive com companheiro e filho(s) ou outros familiares")]
        ConviveComCompanheiroComFilhosOuOutrosFamiliares = 3,
        [Display(Name = "Convive com familiares sem companheiro")]
        ConviveComFamiliaresSemCompanheiro = 4,
        [Display(Name = "Convive com outra(s) pessoa(s)")]
        ConviveComOutrasPessoas = 5,
        [Display(Name = "Vive só")]
        ViveSo = 6,
        [Display(Name = "Sem Informação")]
        SemInformacao = 7
    }
}
