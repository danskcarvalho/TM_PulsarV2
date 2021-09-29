using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class DadosOdontologicos
    {
        public bool? Amamentando { get; set; }
        public bool? SangramentoAoEscovarDente { get; set; }
        public bool? RangeDentes { get; set; }
        public bool? DoresOuvido { get; set; }
        public bool? CondicoesPreExistentes { get; set; }
        public bool? Alergias { get; set; }
        public bool? VacinacaoEmDia { get; set; }
        public bool? NecessidadeEspeciais { get; set; }
        public bool? Gravidez { get; set; }
        public HashSet<PossuiProtese> PossuiProtese { get; set; }
        public HashSet<VigilanciaSaudeBucal> VigilanciaSaudeBucal { get; set; }
        public HashSet<NecessitaProtese> NecessitaProtese { get; set; }
        public HashSet<FornecimentoOdonto> FornecimentoOdonto { get; set; }
        public HashSet<Desdentado> Desdentado { get; set; }
        public bool? DenteExtraNumerario { get; set; }
        public string ObservacoesDenteExtraNumerario { get; set; }
    }
}
