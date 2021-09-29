using Pulsar.Common.Enumerations;
using Pulsar.Domain.Etnias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Pacientes.Models
{
    public class CaracteristicasFisicas
    {
        public bool DeficienciaAuditiva { get; set; }
        public bool DeficienciaVisual { get; set; }
        public bool DeficienciaIntelectual { get; set; }
        public bool DeficienciaFisica { get; set; }
        public bool DeficienciaMental { get; set; }
        public NivelDeficienciaMental? NivelDeficienciaMental { get; set; }
        public RacaCor? RacaCor { get; set; }
        public EtniaResumida Etnia { get; set; }
    }
}
