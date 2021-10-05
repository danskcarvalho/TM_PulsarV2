using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Acompanhamentos.Models
{
    public class PuericulturaAcompanhamento : Acompanhamento
    {
        public PuericulturaAcompanhamento()
        {
            Tipo = Pulsar.Common.Enumerations.AcompanhamentoTipo.Puericultura;
        }

        public List<PuericulturaAtendimento> DadosAtendimentos { get; set; }
    }
}
