using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class PreNatal
    {
        public RiscoGravidez Risco { get; set; }
        public TipoGravidez? Tipo { get; set; }
        public int? IdadeGestacionalDias { get; set; }
        public DateTime? Dpp { get; set; }
        public decimal? AlturaUterina { get; set; }
        public decimal? BatimentoCardiacoFetal { get; set; }
        public EdemaGravidez? Edema { get; set; }
        public bool? MovimentacaoFetal { get; set; }
        public bool? GravidezPlanejada { get; set; }
        public bool? AceitacaoGravidez { get; set; }
        public bool? RedeSuporteGravidez { get; set; }
        public bool? FumaDuranteGravidez { get; set; }
        public bool? AlcoolismoDuranteGravidez { get; set; }
        public bool? EsforcoFisicoDuranteGravidez { get; set; }
        public bool? EstresseDuranteGravidez { get; set; }
        public bool? ExposicaoQuimicosGravidez { get; set; }
        public bool? ExposicaoFisicosGravidez { get; set; }
        public bool? ViolenciaDomesticaGravidez { get; set; }
        public bool? AnemiaGravidez { get; set; }
        public bool? IsoRhGravidez { get; set; }
        public bool? OligoGravidez { get; set; }
        public bool? CiurGravidez { get; set; }
        public bool? PosDatismoGravidez { get; set; }
        public bool? FebreGravidez { get; set; }
        public bool? InsulinaGravidez { get; set; }
        public bool? AlteracaoGenitalia { get; set; }
        public bool? PalpacaoObstetrica { get; set; }
        public string PalpacaoObstetricaJustificativa { get; set; }
        public bool? AlteracaoTireoide { get; set; }
        public bool? AlteracaoMamas { get; set; }
        public bool? SangramentoVaginal { get; set; }
    }
}
