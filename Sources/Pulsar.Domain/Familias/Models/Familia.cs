using MongoDB.Bson;
using Pulsar.Domain.Comum;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Pacientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Familias.Models
{
    public class Familia
    {
        public ObjectId Id { get; set; }
        public ObjectId EstabelecimentoId { get; set; }
        public string Codigo { get; set; }
        public ObjectId ResponsavelId { get; set; }
        public ObjectId EquipeId { get; set; }
        public string Microarea { get; set; }
        public List<FamiliaIntegrante> Integrantes { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
