using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Usuarios.Models
{
    public class UsuarioResumido
    {
        public ObjectId UsuarioId { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cns { get; set; }
        public Sexo? Sexo { get; set; }
        public DateTime? DataNascimento { get; set; }
        public ConselhoProfissional ConselhoProfissional { get; set; }
    }
}
