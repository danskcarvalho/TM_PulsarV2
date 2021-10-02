using MongoDB.Bson;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class PrescricaoExames : ArtefatoAtendimento
    {
        public PrescricaoExames()
        {
            Tipo = Pulsar.Common.Enumerations.ArtefatoAtendimentoTipo.PrescricaoExames;
        }
        public List<ExameItem> Items { get; set; }
    }

    public class ExameItem
    {
        public ObjectId ItemId { get; set; }
        public ObjectId? ProntuarioId { get; set; }
        public ProcedimentoResumido Procedimento { get; set; }
        public List<DiagnosticoResumido> Diagnosticos { get; set; }
        public string Justificativa { get; set; }
        public PrescricaoExameResultado Resultado { get; set; }
    }
}
