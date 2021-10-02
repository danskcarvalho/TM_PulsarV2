using MongoDB.Bson;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Common
{
    public class DataRegistro
    {
        public DateTime? CriadoEm { get; set; }
        public ObjectId? CriadoPorUsuarioId { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public ObjectId? AtualizadoPorUsuarioId { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public ObjectId? DeletadoPorUsuarioId { get; set; }
    }
}
