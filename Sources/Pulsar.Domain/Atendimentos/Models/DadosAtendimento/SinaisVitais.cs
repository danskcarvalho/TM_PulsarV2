using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class SinaisVitais
    {
        public decimal? PressaoArterialSistolica { get; set; }
        public decimal? PressaoArterialDiastolica { get; set; }
        public decimal? FrequenciaRespiratoria { get; set; }
        public decimal? FrequenciaCardiaca { get; set; }
        public decimal? Temperatura { get; set; }
        public decimal? SituacaoO2 { get; set; }
    }
}
