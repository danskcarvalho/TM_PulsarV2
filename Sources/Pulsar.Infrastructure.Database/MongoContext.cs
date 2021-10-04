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
        private List<Func<Task>> _FlushActions = new List<Func<Task>>();
        private Dictionary<Type, (CancellationToken? CancellationToken, List<object> Objects, Func<List<object>, CancellationToken?, Task> InsertMany)> _Insertions = 
            new Dictionary<Type, (CancellationToken? CancellationToken, List<object> Objects, Func<List<object>, CancellationToken?, Task> InsertMany)>();

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

        internal void AddFlushAction(Func<Task> action)
        {
            _FlushActions.Add(action);
        }
        internal void AddInsert(Type type, object obj, CancellationToken? ct, Func<List<object>, CancellationToken?, Task> insertMany)
        {
            if (_Insertions.ContainsKey(type))
            {
                var i = _Insertions[type];
                i.Objects.Add(obj);
            }
            else
                _Insertions[type] = (ct, new List<object> { obj }, insertMany);
        }
        internal void AddInsertMany(Type type, IEnumerable<object> objs, CancellationToken? ct, Func<List<object>, CancellationToken?, Task> insertMany)
        {
            if (_Insertions.ContainsKey(type))
            {
                var i = _Insertions[type];
                i.Objects.AddRange(objs);
            }
            else
                _Insertions[type] = (ct, new List<object>(objs), insertMany);
        }

        public async Task Flush()
        {
            try
            {
                foreach (var item in _Insertions)
                {
                    await item.Value.InsertMany(item.Value.Objects, item.Value.CancellationToken);
                }
                foreach (var item in _FlushActions)
                {
                    await item();
                }
            }
            finally
            {
                _FlushActions.Clear();
            }
        }
    }
}
