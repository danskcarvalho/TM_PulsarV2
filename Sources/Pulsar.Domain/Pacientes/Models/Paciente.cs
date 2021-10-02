using MongoDB.Bson;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Pacientes.Models
{
    public class Paciente
    {
        public ObjectId Id { get; set; }
        public string TermosPesquisa { get; set; }
        public PacienteHistorico DadosAtuais { get; set; }
        public bool Anonimo { get; set; }
        public ObjectId? AntecedentesPessoais { get; set; }
        public ObjectId? AntecedentesFamiliares { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
        public List<PacienteHistorico> Historico { get; set; }
    }
}
