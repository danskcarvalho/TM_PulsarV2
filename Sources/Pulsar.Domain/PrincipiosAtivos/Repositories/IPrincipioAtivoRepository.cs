using Pulsar.Common.Database;
using Pulsar.Domain.PrincipiosAtivos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.PrincipiosAtivos.Repositories
{
    public interface IPrincipioAtivoRepository : IAsyncRepository<PrincipioAtivo>
    {
    }
}
