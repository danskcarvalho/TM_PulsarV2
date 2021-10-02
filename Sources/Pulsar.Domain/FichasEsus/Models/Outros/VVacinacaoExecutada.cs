using Pulsar.Domain.Global.Models;
using System;

namespace Pulsar.Domain.FichasEsus.Models
{
    public class VVacinacaoExecutada
    {
        public MaterialResumido Imunobiologico { get; set; }
        public EstrategiaVacinacao EstrategiaVacinacao { get; set; }
        public DoseVacinacao Dose { get; set; }
        public string Lote { get; set; }
        public string Fabricante { get; set; }
        public bool? StRegistroAnterior { get; set; }
        public DateTime? DataRegistroAnterior { get; set; }
    }
}