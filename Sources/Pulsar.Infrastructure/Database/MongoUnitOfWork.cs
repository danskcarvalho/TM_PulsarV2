using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Database
{
    public class MongoUnitOfWork
    {
        public MongoUnitOfWork(IClientSessionHandle session, IMongoClient client, CancellationToken ct, 
            IMongoDatabase db, MongoUnitOfWorkOptions options)
        {
            this.Session = session;
            this.CancellationToken = ct;
            this.Database = db;
            this.Options = options;
            this.Client = client;
        }

        public IClientSessionHandle Session { get; }
        public IMongoClient Client { get; }
        public IMongoDatabase Database { get; }
        public CancellationToken CancellationToken { get; }
        public MongoUnitOfWorkOptions Options { get; }
        public IMongoCollection<T> GetCollection<T>(string name) => this.Database.GetCollection<T>(name);
    }
}
