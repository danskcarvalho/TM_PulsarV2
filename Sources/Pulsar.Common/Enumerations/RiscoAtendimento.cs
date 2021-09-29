using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    /// <summary>
    /// Seguindo o padrão do LEDI.
    /// </summary>
    public enum RiscoAtendimento
    {
        Emergencia = 3,
        Urgencia = 2,
        Prioritario = 1,
        NaoInformado = 0
    }
}
