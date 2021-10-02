using Pulsar.Common.Enumerations;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class Motivo
    {
        public  DiagnosticoResumido Ciap2 { get; set; }
        public  string Observacoes { get; set; }
        public  CategoriaMotivoProblema Categoria { get; set; }
    }
}
