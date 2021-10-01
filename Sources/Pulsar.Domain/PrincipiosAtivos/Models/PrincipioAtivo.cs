using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.PrincipiosAtivos.Models
{
    public class PrincipioAtivo
    {
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public string CodigoEsus { get; set; }
        public CategoriaMedicamento Categoria { get; set; }
        public TipoMedicamento Tipo { get; set; }
        public string TermosPesquisa { get; set; }
    }
}
