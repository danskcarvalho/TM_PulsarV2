using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Common;
using Pulsar.Domain.Pacientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuarios.Models
{
    public class FragmentoProntuario
    {
        public ObjectId Id { get; set; }
        public ArtefatoProntuarioTipo Tipo { get; set; }
        public ObjectId PacienteId { get; set; }
        public FragmentoProntuarioDados Atual { get; set; }
        /// <summary>
        /// Atendimento que gerou o prontuário.
        /// </summary>
        public ObjectId AtendimentoGeradorId { get; set; }
        public List<FragmentoProntuarioDados> Historico { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
