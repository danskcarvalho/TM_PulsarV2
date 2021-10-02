using Pulsar.Common.Enumerations;
using Pulsar.Domain.ProcedimentosOdontologicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoOdontologico : AtendimentoComProfissional
    {
        public AtendimentoOdontologico()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtendimento.Odontologico;
        }
        public Antropometria Antropometria { get; set; }
        public Avaliacao Avaliacao { get; set; }
        public DadosOdontologicos DadosOdontologicos { get; set; }
        public ExameFisico ExameFisico { get; set; }
        public MedicaoGlicemia MedicaoGlicemia { get; set; }
        public List<Motivo> Motivos { get; set; }
        public Objetivo Objetivo { get; set; }
        public Odontograma Odontograma { get; set; }
        public Plano Plano { get; set; }
        public List<Problema> Problemas { get; set; }
        public SinaisVitais SinaisVitais { get; set; }
        public Subjetivo Subjetivo { get; set; }
        public ProcedimentosOdontologicos ProcedimentosOdontologicos { get; set; }
        public List<CondutaAtendimentoOdontologico> Condutas { get; set; }
    }
}
