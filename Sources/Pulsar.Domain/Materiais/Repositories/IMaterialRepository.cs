using Pulsar.Common.Database;
using Pulsar.Domain.Materiais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Materiais.Repositories
{
    public interface IMaterialRepository : IAsyncRepository<Material>
    {
    }
}
