using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models.Atendimentos
{
    public class PreAtendimento : AtendimentoComProfissional
    {
        public PreAtendimento()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtendimento.PreAtendimento;
        }
        public Antropometria Antropometria { get; set; }
        public ExameFisico ExameFisico { get; set; }
        public MedicaoGlicemia MedicaoGlicemia { get; set; }
        public SinaisVitais SinaisVitais { get; set; }
        public Subjetivo Subjetivo { get; set; }
    }
}
