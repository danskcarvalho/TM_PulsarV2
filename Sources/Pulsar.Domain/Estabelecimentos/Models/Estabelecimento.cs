using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Common;
using Pulsar.Domain.RedesEstabelecimentos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Estabelecimentos.Models
{
    public class Estabelecimento
    {
        public ObjectId Id { get; set; }
        public string TermosPesquisa { get; set; }
        public ObjectId RedeEstabelecimentosId { get; set; }
        public DadosBasicos DadosBasicos { get; set; }
        public Configuracoes Configuracoes { get; set; }
        public Configuracoes ConfiguracoesRede { get; set; }
        public Servicos Servicos { get; set; }
        public Servicos ServicosRede { get; set; }
        public List<LocalChamada> LocaisChamadas { get; set; }
        public List<Chamada> UltimasChamadas { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long ChamadasVersion { get; set; }
        public long DataVersion { get; set; }

        public bool IsPreNatalOuPuerperio(ObjectId servicoId)
        {
            return Servicos != null && (Servicos.PreNatalIds.Contains(servicoId) || Servicos.PuericulturaIds.Contains(servicoId));
        }

        public bool IsPuericultura(ObjectId servicoId)
        {
            return Servicos != null && Servicos.PuericulturaIds.Contains(servicoId);
        }

        public async Task<List<Usuario>> GetProfissionaisPodemAtender(Container container, TipoAtendimento tipoAtendimento)
        {
            var usuarios = await container.Usuarios.FindMany(u => u.DataRegistro.DeletadoEm == null &&
                            u.LotacoesEstabelecimentos.Any(le => (le.EstabelecimentoId == this.Id || le.RedeEstabelecimentosId == this.RedeEstabelecimentosId)
                            && le.Ativo), noSession: true);
            var response = new List<Usuario>();
            foreach (var u in usuarios)
            {
                if (await u.PodeAtender(this, tipoAtendimento, container))
                    response.Add(u);
            }
            return response;
        }
    }
}
