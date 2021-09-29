using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class Puericultura
    {
        public bool? RetornaResultadosExamesEspecificos { get; set; }
        public bool? PotencialEvocadoAuditivoTriagemAuditiva { get; set; }
        public bool? TesteOrelhinha { get; set; }
        public bool? UltraSonografiaTransfontanela { get; set; }
        public bool? TomografiaComputadorizadaCranio { get; set; }
        public bool? RessonanciaMagneticaCranio { get; set; }
        public bool? Fundoscopia { get; set; }
        public bool? TesteReflexoVermelho { get; set; }
        public string ResultadoTesteReflexoVermelho { get; set; }
        public DateTime? DataRealizacaoTesteReflexoVermelho { get; set; }
        public ExameFisicoPuericultura? EstadoNutricional { get; set; }
        public ExameFisicoPuericultura? Crescimento { get; set; }
        public ExameFisicoPuericultura? DNPM { get; set; }
        public ExameFisicoPuericultura? Alimentacao { get; set; }
        public ExameFisicoPuericultura? Vacinacao { get; set; }
        public ExameFisicoPuericultura? AvaliacaoRisco { get; set; }
        public string Eliminacoes { get; set; }
        public List<PuericulturaResposta> Respostas { get; set; }
    }

    public class PuericulturaResposta
    {
        public ObjectId PerguntaId { get; set; }
        public AusenteOuPresente Resposta { get; set; }
    }
}
