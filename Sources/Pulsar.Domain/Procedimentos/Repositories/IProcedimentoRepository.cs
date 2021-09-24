using Pulsar.Common.Database;
using Pulsar.Domain.Procedimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Procedimentos.Repositories
{
    public interface IProcedimentoRepository : IAsyncRepository<Procedimento>
    {
    }
}
