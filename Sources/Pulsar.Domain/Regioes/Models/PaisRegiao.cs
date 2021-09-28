using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Regioes.Models
{
    public class PaisRegiao : Regiao
    {
        public PaisRegiao()
        {
            Tipo = LocalTipo.Pais;
        }
    }
}
