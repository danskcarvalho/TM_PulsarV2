using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Regioes.Models
{
    public class Regiao
    {
        public ObjectId Id { get; set; }
        public virtual LocalTipo Tipo { get; }
        public long Codigo { get; set; }
        public string Nome { get; set; }
        public string TermosPesquisa { get; set; }
        public bool Ativo { get; set; }
    }
}
