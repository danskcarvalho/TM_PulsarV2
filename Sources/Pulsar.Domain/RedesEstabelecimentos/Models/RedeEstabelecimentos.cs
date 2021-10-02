using MongoDB.Bson;
using Pulsar.Domain.Comum;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.RedesEstabelecimentos.Models
{
    public class RedeEstabelecimentos
    {
        public ObjectId Id { get; set; }
        public string TermosPesquisa { get; set; }
        public DadosBasicos DadosBasicos { get; set; }
        public Configuracoes Configuracoes { get; set; }
        public Servicos Servicos { get; set; }
        public MunicipioResumido Municipio { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public RemetenteEsus RemetenteEsus { get; set; }
        public long UltimoLoteEsus { get; set; }
        public long DataVersion { get; set; }
    }
}
