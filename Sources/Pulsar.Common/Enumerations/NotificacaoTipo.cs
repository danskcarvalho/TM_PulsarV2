using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum NotificacaoTipo
    {
        NovoAtendimento = 1,
        AtendimentoAberto = 2,
        ProcedimentosPendentes = 3
    }
}
