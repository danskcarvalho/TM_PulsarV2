using MongoDB.Bson;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Global.Models
{
    public class ChaveCondicaoSaude
    {
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public string TermosPesquisa { get; set; }
        public bool Ativo { get; set; }
        public List<DiagnosticoResumido> Diagnosticos { get; set; }
    }
}
