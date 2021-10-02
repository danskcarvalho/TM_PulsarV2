using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuarios.Models
{
    public class MedicamentoProntuario : FragmentoProntuarioDados
    {
        public MaterialResumido Medicamento { get; set; }
        public TipoMedicamento? TipoReceita { get; set; }
        public ViaAdministracao? ViaAdministracao { get; set; }
        public bool DoseUnica { get; set; }
        public bool UsoContinuo { get; set; }
        public decimal? Dose { get; set; }
        public string DoseTipoManual { get; set; }
        public DoseTipo? DoseTipo { get; set; }
        public int? IntervaloEmHoras { get; set; }
        public MedicamentoFrequencia Frequencia { get; set; }
        public MedicamentoTurno Turno { get; set; }
        public DateTime? InicioTratamento { get; set; }
        public int? DuracaoTratamento { get; set; }
        public UnidadeTempo? DuracaoTratamentoUnidadeTempo { get; set; }
    }
}
