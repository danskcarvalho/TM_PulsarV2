using Pulsar.Common.Database;
using Pulsar.Domain.Pastas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Pastas.Repositories
{
    public interface IPastaRepository : IAsyncRepository<Pasta>
    {
    }
}
