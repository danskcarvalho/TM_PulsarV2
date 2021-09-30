using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Pacientes.Models;
using System;
using System.Collections.Generic;

namespace Pulsar.Domain.FichasEsus.Models
{
    public class VVacinacaoPorPaciente
    {
        public Turno? Turno { get; set; }
        public string NumeroProntuario { get; set; }
        public ObjectId PacienteId { get; set; }
        public Sexo? PacienteSexo { get; set; }
        public DateTime? PacienteDataNascimento { get; set; }
        public string PacienteCPF { get; set; }
        public string PacienteCNS { get; set; }
        public LocalAtendimento? LocalDeAtendimento { get; set; }
        public bool? Viajante { get; set; }
        public bool? ComunicanteHanseniase { get; set; }
        public bool? Gestante { get; set; }
        public bool? Puerpera { get; set; }
        public IList<VVacinacaoExecutada> Vacinas { get; set; }
        public DateTime? DataHoraInicialAtendimento { get; set; }
        public DateTime? DataHoraFinalAtendimento { get; set; }
    }
}