using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Especialidades.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Estabelecimentos.Models
{
    public class EquipeMembro
    {
        public ObjectId ProfissionalId { get; set; }
        public string Microarea { get; set; }
        public EspecialidadeResumida Especialidade { get; set; }
    }
}
