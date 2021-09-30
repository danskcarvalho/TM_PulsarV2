using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Agendamentos.Models;
using Pulsar.Domain.Especialidades.Models;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Pastas.Models;
using Pulsar.Domain.Procedimentos.Models;
using Pulsar.Domain.Servicos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoComProfissional : Atendimento
    {
        public UsuarioResumido Profissional { get; set; }
        public ServicoResumido Servico { get; set; }
        public List<ServicoResumido> UltimosServicos { get; set; }
        public ObjectId Raiz { get; set; }
        public StatusAtendimento Status { get; set; }
        public HistoricoStatus HistoricoStatus { get; set; }
        public RealizacaoAtendimento Realizacao { get; set; }
        public EspecialidadeResumida Especialidade { get; set; }
        public EquipeResumida Equipe { get; set; }
        public AgendamentoResumido Agendamento { get; set; }
        public List<ProcedimentoResumido> ProcedimentosReportados { get; set; }
        public List<PastaArquivo> Documentos { get; set; }
    }
}
