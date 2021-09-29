using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.RedesEstabelecimentos.Models
{
    public class RemetenteEsus
    {
        public string NomeRazaoSocial { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string ContraChave { get; set; }
        public string UuidInstalacao { get; set; }
    }
}
