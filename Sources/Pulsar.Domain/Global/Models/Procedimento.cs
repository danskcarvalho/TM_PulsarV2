using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Global.Models
{
    public class Procedimento
    {
        public ObjectId Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public Sexo? Sexo { get; set; }
        public Complexidade? Complexidade { get; set; }
        public int? IdadeMinimaEmDias { get; set; }
        public int? IdadeMaximaEmDias { get; set; }
        public bool? ProcedimentoAb { get; set; }
        public bool PodeInformarResultadoEspecifico { get; set; }
        public bool PodeInformarResultadoNumerico { get; set; }
        public string TermosPesquisa { get; set; }
        public List<EspecialidadeResumida> Especialidades { get; set; }
        public List<ResultadoEspecifico> ResultadosEspecificos { get; set; }
        public bool Ativo { get; set; }
    }
}
