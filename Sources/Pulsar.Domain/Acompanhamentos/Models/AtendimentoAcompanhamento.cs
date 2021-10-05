using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Common;
using Pulsar.Domain.Global.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Acompanhamentos.Models
{
    public class AtendimentoAcompanhamento
    {
        public ObjectId AtendimentoId { get; set; }
        public StatusAtendimento Status { get; set; }
        public ObjectId? ProfissionalId { get; set; }
        public ObjectId? ServicoId { get; set; }
        public EspecialidadeResumida Especialidade { get; set; }
        public ConselhoProfissional ConselhoProfissional { get; set; }
        public HistoricoStatus HistoricoStatus { get; set; } = new HistoricoStatus();
        public RealizacaoAtendimento Realizacao { get; set; } = new RealizacaoAtendimento();
        public DataRegistro DataRegistro { get; set; }
    }
}
