using Pulsar.Domain.Atendimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuarios.Models
{
    public class PrescricaoProcedimentosProntuario : FragmentoProntuario
    {
        public List<ProcedimentoItem> Items { get; set; }
    }
}
