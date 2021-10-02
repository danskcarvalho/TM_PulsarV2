using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class ExecutarProcedimentoAtividade : Atividade
    {
        public ExecutarProcedimentoAtividade()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtividade.Procedimento;
        }

        public ProcedimentoResumido Procedimento { get; set; }
        public List<DiagnosticoResumido> Diagnosticos { get; set; }
    }
}
