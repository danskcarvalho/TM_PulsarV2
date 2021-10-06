﻿using MongoDB.Bson;
using Pulsar.Common;
using Pulsar.Common.Enumerations;
using Pulsar.Common.Exceptions;
using Pulsar.Domain.Common;
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

        public async Task ChecarPermissaoEstabelecimento(ObjectId? estabelecimentoId, Permissao permissao, 
            Container container)
        {
            if (!await PossuiPermissaoEstabelecimento(estabelecimentoId, permissao, container))
                throw new PulsarException(PulsarErrorCode.Forbidden);
        }
        public async Task<bool> PossuiPermissaoEstabelecimento(ObjectId? estabelecimentoId, Permissao permissao,
           Container container)
        {
            if (estabelecimentoId == null)
                return false;

            if (LotacoesEstabelecimentos == null)
                return false;

            foreach (var le in LotacoesEstabelecimentos)
            {
                if (le.EstabelecimentoId != estabelecimentoId)
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

        public EstabelecimentoLotacao GetLotacao(ObjectId estabelecimentoId)
        {
            return LotacoesEstabelecimentos.FirstOrDefault(le => le.EstabelecimentoId == estabelecimentoId);
        }

        public async Task<bool> PodeAtender(ObjectId estabelecimentoId, TipoAtendimento tipo, Container container)
        {
            return await PossuiPermissaoEstabelecimento(estabelecimentoId, tipo.GetPermissao(), container);
        }

        public Task<FilaAtendimentos> GetFilaAtendimentosDia(Usuario usuario, Estabelecimentos.Models.Estabelecimento estabelecimento, Container container)
        {
            throw new NotImplementedException();
        }
    }
}
