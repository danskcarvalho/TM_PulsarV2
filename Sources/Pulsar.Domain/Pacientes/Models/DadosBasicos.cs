using Pulsar.Common.Enumerations;
using Pulsar.Domain.Comum;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Pacientes.Models
{
    public class DadosBasicos
    {
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string Cns { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Rne { get; set; }
        public string Nis { get; set; }
        public string OrgaoEmissorRg { get; set; }
        public EstadoResumido EstadoEmissorRG { get; set; }
    }
}
