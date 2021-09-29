using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum SituacaoFamiliar
    {
        ConviveComCompanheiroFilho = 1,
        ConviveComCompanheiroLacosConjugaisSemFilhos = 2,
        ConviveComCompanheiroComFilhosOuOutrosFamiliares = 3,
        ConviveComFamiliaresSemCompanheiro = 4,
        ConviveComOutrasPessoas = 5,
        ViveSo = 6,
        SemInformacao = 7
    }
}
