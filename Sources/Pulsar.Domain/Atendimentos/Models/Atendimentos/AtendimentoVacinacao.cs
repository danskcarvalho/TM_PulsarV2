using Pulsar.Domain.Agendamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models.Atendimentos
{
    public class AtendimentoVacinacao : AtendimentoComProfissional
    {
        public AtendimentoVacinacao()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtendimento.Vacinacao;
        }

        public CondicoesPacienteVacinacao CondicoesPaciente { get; set; }
        public List<AgendamentoVacinacao> Aprazadas { get; set; }
    }
}
