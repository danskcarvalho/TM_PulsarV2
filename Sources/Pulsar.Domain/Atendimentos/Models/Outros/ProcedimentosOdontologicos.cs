using MongoDB.Bson;
using Pulsar.Domain.ProcedimentosOdontologicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class ProcedimentosOdontologicos
    {
        public List<ObjectId> Criados { get; set; }
        public List<ObjectId> Concluidos { get; set; }
        public List<ObjectId> Desfeitos { get; set; }
    }
}
