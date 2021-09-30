using MongoDB.Bson;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Diagnosticos.Models;
using Pulsar.Domain.Procedimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuario.Models
{
    public class ExameProntuario : ProntuarioDados
    {
        public ProcedimentoResumido Procedimento { get; set; }
        public List<DiagnosticoResumido> Diagnosticos { get; set; }
        public string Justificativa { get; set; }
        public PrescricaoExameResultado Resultado { get; set; }
    }
}
