using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Database
{
    public class MongoWorker
    {
        public MongoContextFactory Factory { get; }

        public MongoWorker(MongoContextFactory factory)
        {
            this.Factory = factory;
        }
    }

    public class MongoWorker<T> : MongoWorker
    {
        public MongoWorker(string collectionName, MongoContextFactory factory) : base(factory)
        {
            this.CollectionName = collectionName;
        }
        public string CollectionName { get; }
        public IMongoCollection<T> Collection(MongoContext uow) => uow.GetCollection<T>(CollectionName);
    }
}
