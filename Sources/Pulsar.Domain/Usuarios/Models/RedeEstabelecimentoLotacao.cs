using Pulsar.Domain.Comum;
using Pulsar.Domain.Perfis.Models;
using Pulsar.Domain.RedesEstabelecimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Usuarios.Models
{
    public class RedeEstabelecimentoLotacao
    {
        public RedeEstabelecimentosResumida RedeEstabelecimentos { get; set; }
        public bool IsRoot { get; set; }
        public PerfilResumido Perfil { get; set; }
        public CriacaoAtualizacao CriacaoAtualizacao { get; set; }
        public bool Ativo { get; set; }
    }
}
