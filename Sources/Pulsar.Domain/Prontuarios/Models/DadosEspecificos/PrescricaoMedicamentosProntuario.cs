using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Atendimentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuarios.Models
{
    public class PrescricaoMedicamentosProntuario : ProntuarioDados
    {
        public TipoMedicamento? TipoReceita { get; set; }
        public List<MedicamentoItem> Items { get; set; }
    }
}
