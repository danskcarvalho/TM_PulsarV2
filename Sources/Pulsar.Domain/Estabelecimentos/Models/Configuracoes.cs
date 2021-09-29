using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Estabelecimentos.Models
{
    public class Configuracoes
    {
        public bool CriarPreAtendimento { get; set; }
        public ConfiguracaoAgenda ConfiguracaoAgenda { get; set; }
    }
}
