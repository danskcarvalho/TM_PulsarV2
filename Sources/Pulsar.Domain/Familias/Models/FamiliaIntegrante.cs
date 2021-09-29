using Pulsar.Domain.Pacientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Familias.Models
{
    public class FamiliaIntegrante
    {
        public PacienteResumido Integrante { get; set; }
        public PacienteResumido Responsavel { get; set; }
    }
}
