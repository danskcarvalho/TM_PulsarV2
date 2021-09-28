using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Usuarios.Models
{
    public class DadosBasicos
    {
        public string Email { get; set; }
        public string SenhaSalt { get; set; }
        public string SenhaHash { get; set; }
        public string ImagemPerfilUrl { get; set; }
        public bool Ativado { get; set; }
        public string CodigoConfirmacaoEmail { get; set; }
        public string CodigoConfirmacaoEmailExpiraEm { get; set; }
        public int? NumTentativasConfirmacaoEmail { get; set; }
        public string CodigoMudancaSenha { get; set; }
        public string CodigoMudancaSenhaExpiraEm { get; set; }
        public int? NumTentativasMudancaSenha { get; set; }
        public bool Ativo { get; set; }
    }
}
