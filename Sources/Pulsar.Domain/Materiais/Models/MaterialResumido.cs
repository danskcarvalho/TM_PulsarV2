using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Materiais.Models
{
    public class MaterialResumido
    {
        public ObjectId? Id { get; set; }
        public TipoMaterial Tipo { get; set; }
        public bool Ativo { get; set; }
        public string Nome { get; set; }
        public string Forma { get; set; }
        public string Concentracao { get; set; }
    }
}
