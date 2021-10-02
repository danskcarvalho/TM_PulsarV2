using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Global.Models
{
    public class AgrupadorPuericultura
    {
        public ObjectId AgrupadorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool AgruparPorFaixa { get; set; }
    }
}
