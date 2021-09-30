using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.FichasEsus.Models;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.Pastas.Models;
using Pulsar.Domain.Servicos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class Atendimento
    {
        public ObjectId Id { get; set; }
        public ObjectId EstabelecimentoId { get; set; }
        public ObjectId Paciente { get; set; }
        public TipoAtendimento Tipo { get; set; }
        public List<ObjectId> FichasEsus { get; set; }
        public long DataVersion { get; set; }
    }
}
