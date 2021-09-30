using Pulsar.Common.Database;
using Pulsar.Domain.ProcedimentosOdontologicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.ProcedimentosOdontologicos.Repositories
{
    public interface IProcedimentoOdontologicoRepository : IAsyncRepository<ProcedimentoOdontologico>
    {
    }
}
