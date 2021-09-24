using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Migrations
{
    public abstract class Migration
    {
        protected IMongoClient Client { get; private set; }
        protected IMongoDatabase Database { get; private set; }

        internal void Set(IMongoClient client, IMongoDatabase db)
        {
            this.Client = client;
            this.Database = db;
        }

        public abstract Task Up();
        protected IMongoCollection<T> GetCollection<T>(string name) => Database.GetCollection<T>(name);

    }
}
