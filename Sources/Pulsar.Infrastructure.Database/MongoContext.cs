using MongoDB.Driver;
using Pulsar.Common.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Database
{
    public class MongoContext : IDbContext
    {
        public MongoContext(IClientSessionHandle session, IMongoClient client, CancellationToken ct, 
            IMongoDatabase db, IsolationOptions options)
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
        public IsolationOptions Options { get; }
        public IMongoCollection<T> GetCollection<T>(string name) => this.Database.GetCollection<T>(name);

        object IDbContext.Session => Session;

        object IDbContext.Client => Client;

        object IDbContext.Database => Database;

        CancellationToken IDbContext.CancellationToken => CancellationToken;

        IsolationOptions IDbContext.Options => Options;
    }
}
