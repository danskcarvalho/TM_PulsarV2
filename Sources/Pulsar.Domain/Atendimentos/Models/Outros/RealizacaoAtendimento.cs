using MongoDB.Bson;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class RealizacaoAtendimento
    {
        public DateTime? Data { get; set; }
        public TimeSpan? Horario { get; set; }
        public TimeSpan? Duracao { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
    }
}
