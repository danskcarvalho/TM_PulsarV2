using Pulsar.Common.Database;
using Pulsar.Domain.Atendimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Repositories
{
    public interface IAtendimentoRepository : IAsyncRepository<Atendimento>
    {
    }
}
