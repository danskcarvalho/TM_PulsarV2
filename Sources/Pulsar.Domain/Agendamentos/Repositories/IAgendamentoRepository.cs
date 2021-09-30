using Pulsar.Common.Database;
using Pulsar.Domain.Agendamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Agendamentos.Repositories
{
    public interface IAgendamentoRepository : IAsyncRepository<Agendamento>
    {
    }
}
