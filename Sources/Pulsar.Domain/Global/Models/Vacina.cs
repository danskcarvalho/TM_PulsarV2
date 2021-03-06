using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Global.Models
{
    public class Vacina : Material
    {
        public Vacina()
        {
            Tipo = TipoMaterial.Vacina;
        }
        public string ImunobiologicoNome { get; set; }
        public int ImunobiologicoId { get; set; }
        public int? OrdemCalendario { get; set; }
        public List<DoseVacinacao> Doses { get; set; }
        public List<EstrategiaVacinacao> Estrategias { get; set; }
        public List<CalendarioVacinacao> Calendario { get; set; }

    }
}
