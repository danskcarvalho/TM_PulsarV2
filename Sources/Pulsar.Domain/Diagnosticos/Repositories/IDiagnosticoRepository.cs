using Pulsar.Common.Database;
using Pulsar.Domain.Diagnosticos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Diagnosticos.Repositories
{
    public interface IDiagnosticoRepository : IAsyncRepository<Diagnostico>
    {
    }
}
