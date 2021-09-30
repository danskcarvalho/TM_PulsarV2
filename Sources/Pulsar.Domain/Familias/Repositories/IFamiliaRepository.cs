using Pulsar.Common.Database;
using Pulsar.Domain.Familias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Familias.Repositories
{
    public interface IFamiliaRepository : IAsyncRepository<Familia>
    {
    }
}
