using MongoDB.Bson;
using Pulsar.Domain.Common;
using Pulsar.Domain.Global.Models;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Perfis.Models;
using Pulsar.Domain.RedesEstabelecimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Usuarios.Models
{
    public class EstabelecimentoLotacao
    {
        public ObjectId EstabelecimentoId { get; set; }
        /// <summary>
        /// Dá permissão a todos os estabelecimentos de uma rede de estabelecimentos.
        /// </summary>
        public ObjectId? RedeEstabelecimentosId { get; set; }
        public ObjectId PerfilId { get; set; }
        public UsuarioEspecialidade EspecialidadeConselho { get; set; }
        public bool Raiz { get; set; }
        public bool Gestor { get; set; }
        public ConselhoProfissional ConselhoProfissional { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public bool Ativo { get; set; }
    }
}
