using Pulsar.Common.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Database
{
    public class MongoRepositoryFactory<T, TRepository> : IAsyncRepositoryFactory<T> 
        where T : class
        where TRepository : class, IAsyncRepository<T>
    {
        IAsyncRepository<T> IAsyncRepositoryFactory<T>.Get(IDbContext ctx)
        {
            return (IAsyncRepository<T>)Activator.CreateInstance(typeof(TRepository), args: new object[] { ctx });
        }
    }
}
