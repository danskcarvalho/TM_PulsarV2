using Pulsar.Common.Database;
using Pulsar.Domain.Etnias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Etnias.Repositories
{
    public interface IEtniaRepository : IAsyncRepository<Etnia>
    {
    }
}
