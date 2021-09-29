using Pulsar.Domain.Servicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.RedesEstabelecimentos.Models
{
    public class Servicos
    {
        public ServicoResumido Puerperio { get; set; }
        public ServicoResumido PreNatal { get; set; }
        public ServicoResumido Puericultura { get; set; }
        public ServicoResumido ConsultaManutencaoOdontologiaServico { get; set; }
        public ServicoResumido ConsultaRetornoOdontologiaServico { get; set; }
        public ServicoResumido PrimeiraConsultaOdontologiaServico { get; set; }
    }
}
