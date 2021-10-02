using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pulsar.Domain.FichasEsus.Models
{
    public class AIProblemaCondicaoAvaliacao
    {
        public List<DiagnosticoResumido> TodosCiaps { get; set; }
        public List<DiagnosticoResumido> TodosCids { get; set; }
        public List<DiagnosticoResumido> Ciaps { get; set; }
        public DiagnosticoResumido OutroCiap1 { get; set; }
        public DiagnosticoResumido OutroCiap2 { get; set; }
        public DiagnosticoResumido Cid10 { get; set; }
        public DiagnosticoResumido Cid10_2 { get; set; }
    }
}
