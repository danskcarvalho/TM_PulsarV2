using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Regioes.Models
{
    public class EstadoRegiao : Regiao
    {
        public EstadoRegiao()
        {
            Tipo = LocalTipo.Estado;
        }

        public string Sigla { get; set; }
        public PaisResumido Pais { get; set; }
    }
}
