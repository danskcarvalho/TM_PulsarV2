using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Common.Exceptions;
using Pulsar.Domain.Common;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Usuarios.Models
{
    public class Usuario
    {
        public ObjectId Id { get; set; }
        public bool Raiz { get; set; }
        public DadosBasicos DadosBasicos { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
        public string TermosPesquisa { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public List<RedeEstabelecimentoLotacao> LotacoesRedesEstabelecimentos { get; set; }
        public List<EstabelecimentoLotacao> LotacoesEstabelecimentos { get; set; }
        public List<UsuarioEspecialidade> Especialidades { get; set; }
        public long DataVersion { get; set; }

        public async Task ChecarPermissaoEstabelecimento(ObjectId? estabelecimentoId, Permissao permissao, 
            Container container)
        {
            if (estabelecimentoId == null)
                throw new PulsarException(PulsarErrorCode.Forbidden);

            if(LotacoesEstabelecimentos == null)
                throw new PulsarException(PulsarErrorCode.Forbidden);

            foreach (var le in LotacoesEstabelecimentos)
            {
                if (le.EstabelecimentoId != estabelecimentoId)
                    continue;

                var perfil = await container.Perfis.FindOneById(le.PerfilId);
                if (perfil.Permissoes.Contains(permissao))
                    return;
            }

            throw new PulsarException(PulsarErrorCode.Forbidden);
        }
    }
}
