using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Database
{
    public interface IAsyncRepositoryFactory<T> where T : class
    {
        IAsyncRepository<T> Get(IDbContext ctx);
    }
}
