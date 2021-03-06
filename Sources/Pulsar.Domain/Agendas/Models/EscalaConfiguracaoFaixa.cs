using MongoDB.Bson;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Servicos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Agendas.Models
{
    public class EscalaConfiguracaoFaixa
    {
        public ObjectId FaixaId { get; set; }
        public List<ObjectId> Profissionais { get; set; }
        public List<ObjectId> Servicos { get; set; }
        public List<ObjectId> ServicosOnlines { get; set; }
        public List<ObjectId> Equipes { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }
        public int? LimiteAgendamentos { get; set; }
    }
}
