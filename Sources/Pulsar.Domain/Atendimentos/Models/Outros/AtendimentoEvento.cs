using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoEvento
    {
        public DateTime OcorreuEm { get; set; }
        public TipoAtendimentoEvento Tipo { get; set; }
        public AtendimentoResumido Atendimento { get; set; }
        public AtividadeResumida Atividade { get; set; }
    }
}
