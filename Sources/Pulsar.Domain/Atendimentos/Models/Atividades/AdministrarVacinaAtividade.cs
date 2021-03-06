using Pulsar.Common.Enumerations;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AdministrarVacinaAtividade : Atividade
    {
        public AdministrarVacinaAtividade()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtividade.Vacinacao;
        }

        public MaterialResumido Vacina { get; set; }
        public EstrategiaVacinacao EstrategiaVacinacao { get; set; }
        public DoseVacinacao Dose { get; set; }
        public string Lote { get; set; }
        public string Fabricante { get; set; }
        public DateTime? ValidadeLote { get; set; }
        public bool? Viajante { get; set; }
        public bool? ComunicanteHanseniase { get; set; }
        public bool? Gestante { get; set; }
        public bool? Puerpera { get; set; }
        public ViaAdministracao? ViaAdministracao { get; set; }
        public LocalAdministracao? LocalAdministracao { get; set; }
    }
}
