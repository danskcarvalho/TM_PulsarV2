using Pulsar.Common.Enumerations;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Pacientes.Models
{
    public class DadosNacionalidade
    {
        public Nacionalidade? Nacionalidade { get; set; }
        public PaisResumido PaisNascimento { get; set; }
        public MunicipioResumido MunicipioNascimento { get; set; }
        public DateTime? DataNaturalizacao { get; set; }
        public string PortariaNaturalizacao { get; set; }
        public DateTime? DataEntradaBrasil { get; set; }
    }
}
