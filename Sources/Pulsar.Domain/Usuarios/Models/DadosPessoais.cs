using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Usuarios.Models
{
    public class DadosPessoais
    {
        public string Cpf { get; set; }
        public string Cns { get; set; }
        public Sexo? Sexo { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
