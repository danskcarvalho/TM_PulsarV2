using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Materiais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos
{
    public class PrescricaoMedicamentos : ArtefatoAtendimento
    {
        public PrescricaoMedicamentos()
        {
            Tipo = ArtefatoAtendimentoTipo.PrescricaoMedicamentos;
        }
        public TipoMedicamento? TipoReceita { get; set; }
        public List<MedicamentoItem> Items { get; set; }
    }
    public class MedicamentoItem
    {
        public ObjectId ItemId { get; set; }
        public MaterialResumido Medicamento { get; set; }
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
        public CategoriaMedicamento? Categoria { get; set; }
    }
}
