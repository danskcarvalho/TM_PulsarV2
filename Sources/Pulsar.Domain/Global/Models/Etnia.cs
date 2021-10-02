using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Global.Models
{
    public class Etnia
    {
        public ObjectId Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string TermosPesquisa { get; set; }
        public bool Ativo { get; set; }
    }
}
