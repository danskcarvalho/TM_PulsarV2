using MongoDB.Bson;
using Pulsar.Domain.Common;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class ProcedimentoReportado
    {
        public ObjectId? ProntuarioId { get; set; }
        public ProcedimentoResumido Procedimento { get; set; }
        public DataRegistro DataRegistro { get; set; }
    }
}
