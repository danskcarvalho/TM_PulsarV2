using MongoDB.Bson;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Estabelecimentos.Models
{
    public class Chamada
    {
        public ObjectId ChamadaId { get; set; }
        public PacienteResumido Paciente { get; set; }
        public LocalChamada Local { get; set; }
        public UsuarioResumido Profissional { get; set; }
        public DateTime Data { get; set; }
    }
}
