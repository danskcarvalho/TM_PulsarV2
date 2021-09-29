using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum StatusImportacao
    {
        Pendente = 1,
        Importando = 2,
        Concluida = 3,
        ConcluidaComErros = 4,
        ComErros = 5
    }
}
