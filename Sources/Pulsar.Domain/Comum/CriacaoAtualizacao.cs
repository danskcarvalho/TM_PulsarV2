using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Comum
{
    public class CriacaoAtualizacao
    {
        public DateTime? CriadoEm { get; set; }
        public ObjectId CriadoPorId { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public ObjectId AtualizadoPorId { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public ObjectId DeletadoPorId { get; set; }
    }
}
