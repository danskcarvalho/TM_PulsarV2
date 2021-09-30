using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Acompanhamentos.Models
{
    public class FinalizacaoPreNatal
    {
        public GeralPreNatalModel Geral { get; set; }
        public PuerperioPreNatalModel Puerperio { get; set; }
        public class GeralPreNatalModel
        {
            public DesfechoGestacional? Desfecho { get; set; }
            public DateTime? DataDesfecho { get; set; }
            public TipoParto? TipoParto { get; set; }
            public bool? Episiotomia { get; set; }
            public bool? DiuPosParto { get; set; }
            public bool? Prematuro { get; set; }
            public bool? SangramentoNormal { get; set; }
            public int? Apgar1Min { get; set; }
            public int? Apgar5Min { get; set; }
            public int? Apgar10Min { get; set; }
            public DateTime? AltaMaternidade { get; set; }
            public decimal? PesoAlta { get; set; }
            public string MotivoCesarea { get; set; }
            public string MedicamentosUsados { get; set; }
            public string Intercorrencias { get; set; }
        }

        public class PuerperioPreNatalModel
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
}
