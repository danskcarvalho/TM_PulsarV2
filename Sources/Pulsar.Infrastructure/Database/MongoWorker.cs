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
        public MongoUnitOfWorkFactory Factory { get; }

        public MongoWorker(MongoUnitOfWorkFactory factory)
        {
            this.Factory = factory;
        }
    }

    public class MongoWorker<T> : MongoWorker
    {
        public MongoWorker(string collectionName, MongoUnitOfWorkFactory factory) : base(factory)
        {
            this.CollectionName = collectionName;
        }
        public string CollectionName { get; }
        public IMongoCollection<T> Collection(MongoUnitOfWork uow) => uow.GetCollection<T>(CollectionName);
    }
}
