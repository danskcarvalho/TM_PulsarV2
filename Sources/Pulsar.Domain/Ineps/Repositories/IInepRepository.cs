using Pulsar.Common.Database;
using Pulsar.Domain.Ineps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Ineps.Repositories
{
    public interface IInepRepository : IAsyncRepository<Inep>
    {
    }
}
