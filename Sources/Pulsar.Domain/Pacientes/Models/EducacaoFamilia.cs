using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Pacientes.Models
{
    public class EducacaoFamilia
    {
        public bool FrequentaEscola { get; set; }
        public Escolaridade? Escolaridade { get; set; }
        public SituacaoFamiliar? SituacaoFamiliar { get; set; }
        public EstadoCivil? EstadoCivil { get; set; }
    }
}
