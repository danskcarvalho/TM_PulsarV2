using MongoDB.Bson;
using Pulsar.Domain.Regioes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Ineps.Models
{
    public class Inep
    {
        public ObjectId Id { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string TermosPesquisa { get; set; }
        public virtual MunicipioResumido Municipio { get; set; }
        public bool Ativo { get; set; }
    }
}
