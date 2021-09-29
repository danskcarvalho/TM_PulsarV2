using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class RegistroEvasao
    {
        public MotivoEvasao Motivo { get; set; }
        public string Observacoes { get; set; }
    }
}
