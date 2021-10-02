using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Estabelecimentos.Models
{
    public class Equipe
    {
        public ObjectId Id { get; set; }
        public ObjectId EstabelecimentoId { get; set; }
        public string Nome { get; set; }
        public string CodigoIne { get; set; }
        public string CodigoArea { get; set; }
        public List<EquipeMembro> Membros { get; set; }
    }
}
