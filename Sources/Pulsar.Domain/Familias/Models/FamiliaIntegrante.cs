using MongoDB.Bson;
using Pulsar.Domain.Pacientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Familias.Models
{
    public class FamiliaIntegrante
    {
        public ObjectId IntegranteId { get; set; }
        public ObjectId? ResponsavelId { get; set; }
    }
}
