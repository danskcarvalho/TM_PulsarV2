using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.Servicos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoResumido
    {
        public ObjectId AtendimentoId { get; set; }
        public ObjectId? AtendimentoRaizId { get; set; }
        public ObjectId? AtendimentoPaiId { get; set; }
        public EstabelecimentoResumido Estabelecimento { get; set; }
        public PacienteResumido Paciente { get; set; }
        public TipoAtendimento Tipo { get; set; }
        public ServicoResumido Servico { get; set; }
        public StatusAtendimento? Status { get; set; }
        public List<UsuarioResumido> Profissionais { get; set; }
    }
}
