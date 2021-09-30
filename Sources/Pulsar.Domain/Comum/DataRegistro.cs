using MongoDB.Bson;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Comum
{
    public class DataRegistro
    {
        public DateTime? CriadoEm { get; set; }
        public UsuarioResumido CriadoPorId { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public UsuarioResumido AtualizadoPorId { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public UsuarioResumido DeletadoPorId { get; set; }
    }
}
