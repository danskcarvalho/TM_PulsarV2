using MongoDB.Bson;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Acompanhamentos.Models
{
    public class PuericulturaAtendimento : AtendimentoAcompanhamento
    {
        public Antropometria Antropometria { get; set; }
        public SinaisVitais SinaisVitais { get; set; }
        public MedicaoGlicemia MedicaoGlicemia { get; set; }
        public Puericultura Puericultura { get; set; }
    }
}
