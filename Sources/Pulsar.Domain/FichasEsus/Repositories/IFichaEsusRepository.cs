using Pulsar.Common.Database;
using Pulsar.Domain.FichasEsus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.FichasEsus.Repositories
{
    public interface IFichaEsusRepository : IAsyncRepository<FichaEsus>
    {
    }
}
