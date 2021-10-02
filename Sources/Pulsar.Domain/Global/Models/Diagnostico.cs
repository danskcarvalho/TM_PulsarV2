using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Global.Models
{
    public class Diagnostico
    {
        public ObjectId Id { get; set; }
        public TipoDiagnostico Tipo { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public Sexo? Sexo { get; set; }
        public string TermosPesquisa { get; set; }
        public bool Ativo { get; set; }
        public List<DiagnosticoResumido> Correlatos { get; set; }
    }
}
