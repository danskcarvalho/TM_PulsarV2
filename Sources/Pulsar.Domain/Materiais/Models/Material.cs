using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Materiais.Models
{
    public class Material
    {
        public ObjectId Id { get; set; }
        public virtual string Nome { get; }
        public virtual TipoMaterial Tipo { get; }
        public string TermosPesquisa { get; set; }
        public bool Ativo { get; set; }
    }
}
