using Pulsar.Common.Database;
using Pulsar.Domain.Dentes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Dentes.Repositories
{
    public interface IDenteRepository : IAsyncRepository<Dente>
    {
    }
}
