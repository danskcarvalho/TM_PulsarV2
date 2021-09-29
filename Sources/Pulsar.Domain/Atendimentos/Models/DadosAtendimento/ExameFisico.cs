using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class ExameFisico
    {
        public bool? PeleMucosa { get; set; }
        public bool? CabecaPescoco { get; set; }
        public bool? MembrosSuperiores { get; set; }
        public bool? MembrosInferiores { get; set; }
        public bool? AR { get; set; }
        public bool? AC { get; set; }
        public bool? SNC { get; set; }
        public bool? Abdome { get; set; }
        public bool? Genitalia { get; set; }
        public string JustificativaPeleMucosa { get; set; }
        public string JustificativaCabecaPescoco { get; set; }
        public string JustificativaMembrosSuperiores { get; set; }
        public string JustificativaMembrosInferiores { get; set; }
        public string JustificativaAR { get; set; }
        public string JustificativaAC { get; set; }
        public string JustificativaSNC { get; set; }
        public string JustificativaAbdome { get; set; }
        public string JustificativaGenitalia { get; set; }
    }
}
