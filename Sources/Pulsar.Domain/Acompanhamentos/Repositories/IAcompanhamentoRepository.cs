using Pulsar.Common.Database;
using Pulsar.Domain.Acompanhamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Acompanhamentos.Repositories
{
    public interface IAcompanhamentoRepository : IAsyncRepository<Acompanhamento>
    {
    }
}
