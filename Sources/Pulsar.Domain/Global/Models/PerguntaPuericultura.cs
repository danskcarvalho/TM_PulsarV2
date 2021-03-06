using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Global.Models
{
    public class PerguntaPuericultura
    {
        public ObjectId Id { get; set; }
        public AgrupadorPuericultura Agrupador { get; set; }
        public FaixaPuericultura Faixa { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool ExibirAlcancadoEm { get; set; }
        public bool Ativo { get; set; }
    }
}
