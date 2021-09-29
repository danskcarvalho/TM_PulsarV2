using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Pacientes.Models
{
    public class PacienteResumido
    {
        public ObjectId PacienteId { get; set; }
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        public string NomeMae { get; set; }
        public string Cpf { get; set; }
        public string Cns { get; set; }
        public Sexo? Sexo { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
