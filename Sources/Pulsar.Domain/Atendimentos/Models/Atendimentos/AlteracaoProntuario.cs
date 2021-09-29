using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models.Atendimentos
{
    public class AlteracaoProntuario : AtendimentoComProfissional
    {
        public AlteracaoProntuario()
        {
            Tipo = Common.Enumerations.TipoAtendimento.AlteracaoProntuario;
        }

        public DateTime Data { get; set; }
    }
}
