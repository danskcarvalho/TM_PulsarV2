using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Servicos.Models
{
    public class Restricoes
    {
        public Sexo? Sexo { get; set; }
        public int? IdadeMinimaEmDias { get; set; }
        public int? IdadeMaximaEmDias { get; set; }
    }
}
