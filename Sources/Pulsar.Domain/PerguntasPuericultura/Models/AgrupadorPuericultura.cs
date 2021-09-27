using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.PerguntasPuericultura.Models
{
    public class AgrupadorPuericultura
    {
        public virtual ObjectId AgrupadorId { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool AgruparPorFaixa { get; set; }
    }
}
