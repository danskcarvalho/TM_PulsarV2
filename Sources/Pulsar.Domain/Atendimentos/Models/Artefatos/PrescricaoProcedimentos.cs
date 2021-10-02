using MongoDB.Bson;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class PrescricaoProcedimentos : ArtefatoAtendimento
    {
        public PrescricaoProcedimentos()
        {
            Tipo = Common.Enumerations.ArtefatoAtendimentoTipo.PrescricaoProcedimentos;
        }
        public List<ProcedimentoItem> Items { get; set; }
    }

    public class ProcedimentoItem
    {
        public ObjectId ItemId { get; set; }
        public ProcedimentoResumido Procedimento { get; set; }
        public List<DiagnosticoResumido> Diagnosticos { get; set; }
        public string Justificativa { get; set; }
    }
}
