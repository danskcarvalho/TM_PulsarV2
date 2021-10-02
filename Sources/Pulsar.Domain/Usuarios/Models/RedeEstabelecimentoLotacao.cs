using MongoDB.Bson;
using Pulsar.Domain.Common;
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
        public ObjectId RedeEstabelecimentosId { get; set; }
        public bool Raiz { get; set; }
        public ObjectId PerfilId { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public bool Ativo { get; set; }
    }
}
