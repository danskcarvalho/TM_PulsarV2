using MongoDB.Bson;
using Pulsar.Common;
using Pulsar.Common.Enumerations;
using Pulsar.Common.Exceptions;
using Pulsar.Domain.Common;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.FilasAtendimentos.Models;
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

        public async Task ChecarPermissaoEstabelecimento(Estabelecimento estabelecimento, Permissao permissao, 
            Container container)
        {
            if (!await PossuiPermissaoEstabelecimento(estabelecimento, permissao, container))
                throw new PulsarException(PulsarErrorCode.Forbidden);
        }
        public async Task<bool> PossuiPermissaoEstabelecimento(Estabelecimento estabelecimento, Permissao permissao,
           Container container)
        {
            if (estabelecimento == null)
                return false;

            if (LotacoesEstabelecimentos == null)
                return false;

            foreach (var le in LotacoesEstabelecimentos)
            {
                if (le.EstabelecimentoId != estabelecimento.Id && le.RedeEstabelecimentosId != estabelecimento.RedeEstabelecimentosId)
                    continue;

                if (!le.Ativo)
                    continue;

                if (le.PerfilId == null)
                    continue;

                var perfil = await container.Perfis.FindOneById(le.PerfilId.Value, noSession: true);
                if (perfil.Permissoes.Contains(permissao))
                    return true;
            }

            return false;
        }

        public EstabelecimentoLotacao GetLotacao(Estabelecimento estabelecimento)
        {
            var lotacao = LotacoesEstabelecimentos.FirstOrDefault(le => le.EstabelecimentoId == estabelecimento.Id);
            if (lotacao == null)
                lotacao = LotacoesEstabelecimentos.FirstOrDefault(le => le.RedeEstabelecimentosId == estabelecimento.RedeEstabelecimentosId);
            if (!lotacao.Ativo)
                return null;
            return lotacao;
        }

        public async Task<bool> PodeAtender(Estabelecimento estabelecimento, TipoAtendimento tipo, Container container)
        {
            return await PossuiPermissaoEstabelecimento(estabelecimento, tipo.GetPermissao(), container);
        }

        public async Task<List<ItemFilaAtendimentos>> GetItensFilaAtendimentosDia(Usuario usuario, Estabelecimento estabelecimento, Container container)
        {
            return await container.ItensFilaAtendimentos.FindMany(fa => fa.ProfissionalId == this.Id &&
                fa.EstabelecimentoId == estabelecimento.Id &&
                fa.Data == DateTime.Today);
        }
    }
}
