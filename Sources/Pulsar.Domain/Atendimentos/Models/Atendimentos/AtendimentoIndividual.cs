using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoIndividual : AtendimentoComProfissional
    {
        public Antropometria Antropometria { get; set; }
        public Avaliacao Avaliacao { get; set; }
        public DesfechoPreNatal DesfechoPreNatal { get; set; }
        public ExameFisico ExameFisico { get; set; }
        public MedicaoGlicemia MedicaoGlicemia { get; set; }
        public List<Motivo> Motivos { get; set; }
        public Objetivo Objetivo { get; set; }
        public Plano Plano { get; set; }
        public PreNatal PreNatal { get; set; }
        public List<Problema> Problemas { get; set; }
        public Puericultura Puericultura { get; set; }
        public Puerperio Puerperio { get; set; }
        public SaudeMulher SaudeMulher { get; set; }
        public SinaisVitais SinaisVitais { get; set; }
        public Subjetivo Subjetivo { get; set; }
        public List<CondutaAtendimentoIndividual> Condutas { get; set; }
    }
}
