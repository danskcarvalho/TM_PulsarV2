using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class EscutaInicial : AtendimentoComProfissional 
    {
        public EscutaInicial()
        {
            Tipo = Common.Enumerations.TipoAtendimento.EscutaInicial;
        }

        public Subjetivo Subjetivo { get; set; }
        public Objetivo Objetivo { get; set; }
        public Antropometria Antropometria { get; set; }
        public SinaisVitais SinaisVitais { get; set; }
        public MedicaoGlicemia MedicaoGlicemia { get; set; }
        public ExameFisico ExameFisico { get; set; }
        public RiscoAtendimento? Risco { get; set; }
    }
}
