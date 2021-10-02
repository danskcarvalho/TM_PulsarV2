using Pulsar.Common.Enumerations;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Estabelecimentos.Models
{
    public class DadosBasicos
    {
        public  string Nome { get; set; }
        public  string Cnes { get; set; }
        public  string Sigla { get; set; }
        public  string Apelido { get; set; }
        public  Endereco Endereco { get; set; }
        public  EstabelecimentoTipo Tipo { get; set; }
        public  Complexidade Complexidade { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Telefone3 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
    }
}
