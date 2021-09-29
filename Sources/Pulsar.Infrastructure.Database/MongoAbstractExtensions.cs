using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Pulsar.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Database
{
    public class MongoAbstractExtensions : IAbstractExtensions
    {
        public Task<T> FirstAsync<T>(IQueryable<T> queryable)
        {
            return ((IMongoQueryable<T>)queryable).FirstAsync();
        }

        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable)
        {
            return ((IMongoQueryable<T>)queryable).FirstOrDefaultAsync();
        }

        public Task<List<T>> ToListAsync<T>(IQueryable<T> queryable)
        {
            return ((IMongoQueryable<T>)queryable).ToListAsync();
        }
    }
}
