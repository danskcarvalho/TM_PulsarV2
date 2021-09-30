using Pulsar.Common.Enumerations;
using Pulsar.Domain.Pacientes;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.Procedimentos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pulsar.Domain.FichasEsus.Models
{
    public class PProcedimentoPorPaciente
    {
        public string NumeroProntuario { get; set; }
        public PacienteResumido Paciente { get; set; }
        public Sexo? PacienteSexo { get; set; }
        public DateTime? PacienteDataNascimento { get; set; }
        public string PacienteCPF { get; set; }
        public string PacienteCNS { get; set; }
        public LocalAtendimento? LocalDeAtendimento { get; set; }
        public Turno? Turno { get; set; }
        public bool? StatusEscutaInicialOrientacao { get; set; }
        public List<ProcedimentoResumido> Procedimentos { get; set; }
        public DateTime? DataHoraInicialAtendimento { get; set; }
        public DateTime? DataHoraFinalAtendimento { get; set; }
    }
}
