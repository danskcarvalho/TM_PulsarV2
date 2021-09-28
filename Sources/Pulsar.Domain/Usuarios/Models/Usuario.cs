using MongoDB.Bson;
using Pulsar.Domain.Comum;
using Pulsar.Domain.Especialidades.Models;
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
        public bool IsRoot { get; set; }
        public DadosBasicos DadosBasicos { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
        public string TermosPesquisa { get; set; }
        public CriacaoAtualizacao CriacaoAtualizacao { get; set; }
        public List<RedeEstabelecimentoLotacao> LotacoesRedesEstabelecimentos { get; set; }
        public List<EstabelecimentoLotacao> LotacoesEstabelecimentos { get; set; }
        public List<EspecialidadeResumida> Especialidades { get; set; }
        public long DataVersion { get; set; }
    }
}
