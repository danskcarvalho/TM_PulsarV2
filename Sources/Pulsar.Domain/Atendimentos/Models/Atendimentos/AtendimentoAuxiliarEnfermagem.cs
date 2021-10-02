using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoAuxiliarEnfermagem : AtendimentoComProfissional
    {
        public AtendimentoAuxiliarEnfermagem()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtendimento.AuxiliarEnfermagem;
        }
        public Antropometria Antropometria { get; set; }
        public ExameFisico ExameFisico { get; set; }
        public MedicaoGlicemia MedicaoGlicemia { get; set; }
        public SinaisVitais SinaisVitais { get; set; }
        public Subjetivo Subjetivo { get; set; }
    }
}
