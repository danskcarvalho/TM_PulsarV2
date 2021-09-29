using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models.DadosAtendimento
{
    public class Puerperio
    {
        public bool? EliminacoesVesicais { get; set; }
        public bool? EliminacoesIntestinais { get; set; }
        public bool? AlteracaoMamas { get; set; }
        public string Perineo { get; set; }
        public string Loquios { get; set; }
        public string CicatrizCirurgica { get; set; }
        public string EstadoEmocional { get; set; }
    }
}
