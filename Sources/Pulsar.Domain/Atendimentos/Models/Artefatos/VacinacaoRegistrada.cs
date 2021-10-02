using Pulsar.Common.Enumerations;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class VacinacaoRegistrada : ArtefatoAtendimento
    {
        public virtual MaterialResumido Vacina { get; set; }
        public virtual EstrategiaVacinacao EstrategiaVacinacao { get; set; }
        public virtual DoseVacinacao Dose { get; set; }
        public virtual bool AplicadaExternamente { get; set; }
        public virtual DateTime? AplicadaEm { get; set; }
        public virtual string Lote { get; set; }
        public virtual DateTime? ValidadeLote { get; set; }
        public virtual string Fabricante { get; set; }
        public virtual bool? Viajante { get; set; }
        public virtual bool? ComunicanteHanseniase { get; set; }
        public virtual bool? Gestante { get; set; }
        public virtual bool? Puerpera { get; set; }
        public virtual ViaAdministracao? ViaAdministracao { get; set; }
        public virtual LocalAdministracao? LocalAdministracao { get; set; }
    }
}
