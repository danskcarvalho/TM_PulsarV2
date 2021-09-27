using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.PerguntasPuericultura.Models
{
    public class PerguntaPuericultura
    {
        public virtual ObjectId Id { get; set; }
        public virtual AgrupadorPuericultura Agrupador { get; set; }
        public virtual FaixaPuericultura Faixa { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool ExibirAlcancadoEm { get; set; }
        public bool Ativo { get; set; }
    }
}
