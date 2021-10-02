using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Acompanhamentos.Models
{
    public class PreNatalAcompanhamento : Acompanhamento
    {
        public PreNatalAcompanhamento()
        {
            Tipo = Pulsar.Common.Enumerations.AcompanhamentoTipo.PreNatal;
        }

        public FinalizacaoPreNatal Finalizacao { get; set; }
        public List<PreNatalAtendimento> DadosAtendimentos { get; set; }
    }
}
