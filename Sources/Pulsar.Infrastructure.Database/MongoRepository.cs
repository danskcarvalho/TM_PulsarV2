using MongoDB.Bson;
using MongoDB.Driver;
using Pulsar.Common.Database;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pulsar.Common;

namespace Pulsar.Infrastructure.Database
{
    public abstract class MongoRepository<T> : IAsyncRepository<T> where T : class
    {
        private PropertyInfo _IdProperty = null;
        protected MongoContext Context { get; }
        protected abstract string CollectionName { get; }

        private IMongoCollection<T> _Collection = null;
        protected IMongoCollection<T> Collection
        {
            get
            {
                _Collection ??= Context.GetCollection<T>(CollectionName);
                return _Collection;
            }
        }

        public MongoRepository(MongoContext ctx)
        {
            this.Context = ctx;
            this._IdProperty = typeof(T).GetProperty("Id");
        }

        async Task IAsyncRepository<T>.DeleteOne(ObjectId id, WriteAck? wc, CancellationToken? ct)
        {
            var collection = Collection;
            if (wc != null)
                collection = collection.WithWriteConcern(wc?.ToWriteConcern());

            var filter = Builders<T>.Filter.Eq("_id", id);
            await collection.DeleteOneAsync(Context.Session, filter,
                cancellationToken: ct ?? CancellationToken.None);
        }

        async Task<T> IAsyncRepository<T>.FindOneById(ObjectId id, ReadAck? rc, ReadPref? rp, CancellationToken? ct)
        {
            var collection = Collection;
            if (rc != null)
                collection = collection.WithReadConcern(rc?.ToReadConcern());
            if (rp != null)
                collection = collection.WithReadPreference(rp?.ToReadPreference());

            var filter = Builders<T>.Filter.Eq("_id", id);
            return await (await collection.FindAsync(Context.Session, filter,
                cancellationToken: ct ?? CancellationToken.None)).FirstOrDefaultAsync();
        }

        async Task IAsyncRepository<T>.InsertMany(IEnumerable<T> items, WriteAck? wc, CancellationToken? ct)
        {
            var collection = Collection;
            if (wc != null)
                collection = collection.WithWriteConcern(wc?.ToWriteConcern());

            await collection.InsertManyAsync(Context.Session, items,
                cancellationToken: ct ?? CancellationToken.None);
        }

        async Task IAsyncRepository<T>.InsertOne(T item, WriteAck? wc, CancellationToken? ct)
        {
            var collection = Collection;
            if (wc != null)
                collection = collection.WithWriteConcern(wc?.ToWriteConcern());

            await collection.InsertOneAsync(Context.Session, item,
                cancellationToken: ct ?? CancellationToken.None);
        }

        async Task IAsyncRepository<T>.UpdateOne(T item, WriteAck? wc, CancellationToken? ct)
        {
            var collection = Collection;
            if (wc != null)
                collection = collection.WithWriteConcern(wc?.ToWriteConcern());

            var filter = Builders<T>.Filter.Eq("_id", (ObjectId)_IdProperty.GetValue(item));
            await collection.FindOneAndReplaceAsync(Context.Session, filter, item,
                cancellationToken: ct ?? CancellationToken.None);
        }

        async Task<T> IAsyncRepository<T>.FindOne(Expression<Func<T, bool>> predicate, ReadAck? rc, ReadPref? rp, CancellationToken? ct)
        {
            var collection = Collection;
            if (rc != null)
                collection = collection.WithReadConcern(rc?.ToReadConcern());
            if (rp != null)
                collection = collection.WithReadPreference(rp?.ToReadPreference());

            return await(await collection.FindAsync(Context.Session, predicate,
                cancellationToken: ct ?? CancellationToken.None)).FirstOrDefaultAsync();
        }

        async Task<List<T>> IAsyncRepository<T>.FindMany(Expression<Func<T, bool>> predicate,
            int? skip,
            int? limit,
            List<Ordering<T>> sortBy,
            ReadAck? rc,
            ReadPref? rp,
            CancellationToken? ct)
        {
            var collection = Collection;
            if (rc != null)
                collection = collection.WithReadConcern(rc?.ToReadConcern());
            if (rp != null)
                collection = collection.WithReadPreference(rp?.ToReadPreference());

            var findOptions = new FindOptions<T>();
            findOptions.Skip = skip;
            findOptions.Limit = limit;
            if (sortBy != null && sortBy.Count != 0)
                findOptions.Sort = BuildSortDefinition(sortBy);

            return await (await collection.FindAsync(Context.Session, predicate, options: findOptions,
                cancellationToken: ct ?? CancellationToken.None)).ToListAsync();
        }

        async Task<List<TProjection>> IAsyncRepository<T>.FindMany<TProjection>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TProjection>> projection,
            int? skip,
            int? limit,
            List<Ordering<T>> sortBy,
            ReadAck? rc,
            ReadPref? rp,
            CancellationToken? ct)
        {
            var collection = Collection;
            if (rc != null)
                collection = collection.WithReadConcern(rc?.ToReadConcern());
            if (rp != null)
                collection = collection.WithReadPreference(rp?.ToReadPreference());

            var findOptions = new FindOptions<T, TProjection>();
            findOptions.Skip = skip;
            findOptions.Limit = limit;
            var projectionDef = Builders<T>.Projection.Expression(projection);
            findOptions.Projection = projectionDef;
            if (sortBy != null && sortBy.Count != 0)
                findOptions.Sort = BuildSortDefinition(sortBy);

            return await (await collection.FindAsync<TProjection>(Context.Session, predicate, options: findOptions,
                cancellationToken: ct ?? CancellationToken.None)).ToListAsync();
        }

        async Task<long> IAsyncRepository<T>.DeleteMany(Expression<Func<T, bool>> predicate, WriteAck? wc, CancellationToken? ct)
        {
            var collection = Collection;
            if (wc != null)
                collection = collection.WithWriteConcern(wc?.ToWriteConcern());

            return (await collection.DeleteManyAsync(Context.Session, predicate,
                cancellationToken: ct ?? CancellationToken.None)).DeletedCount;
        }

        async Task<long> IAsyncRepository<T>.UpdateMany(Expression<Func<T, bool>> predicate, object fields, WriteAck? wc, CancellationToken? ct)
        {
            var collection = Collection;
            if (wc != null)
                collection = collection.WithWriteConcern(wc?.ToWriteConcern());

            return (await collection.UpdateManyAsync(Context.Session, predicate, ToUpdateDefinition(fields),
                cancellationToken: ct ?? CancellationToken.None)).ModifiedCount;
        }

        async Task<long> IAsyncRepository<T>.UpdateOne(Expression<Func<T, bool>> predicate, object fields, WriteAck? wc, CancellationToken? ct)
        {
            var collection = Collection;
            if (wc != null)
                collection = collection.WithWriteConcern(wc?.ToWriteConcern());

            return (await collection.UpdateOneAsync(Context.Session, predicate, ToUpdateDefinition(fields),
                cancellationToken: ct ?? CancellationToken.None)).ModifiedCount;
        }

        private UpdateDefinition<T> ToUpdateDefinition(object fields)
        {
            var setDef = new BsonDocument();
            var pushDef = new BsonDocument();
            var incDef = new BsonDocument();
            var properties = fields.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                var val = prop.GetValue(fields);
                if (val is PushUpdate pu)
                    pushDef.Add(prop.Name, ToBsonValue(pu.Object));
                else if (val is IncUpdate iu)
                    incDef.Add(prop.Name, ToBsonValue(iu.Amount));
                else
                    setDef.Add(prop.Name, ToBsonValue(val));
            }

            var updDef = new BsonDocument();
            if (setDef.ElementCount != 0)
                updDef.Add("$set", setDef);
            if (incDef.ElementCount != 0)
                updDef.Add("$inc", incDef);
            if (pushDef.ElementCount != 0)
                updDef.Add("$push", pushDef);
            return updDef;
        }

        private BsonValue ToBsonValue(object obj)
        {
            var doc = (new { Value = obj }).ToBsonDocument();
            return doc["Value"];
        }

        private SortDefinition<T> BuildSortDefinition(List<Ordering<T>> sortBy)
        {
            var r = sortBy[0] is Ascending<T> ?
                Builders<T>.Sort.Ascending((sortBy[0] as Ascending<T>).Expression) :
                Builders<T>.Sort.Descending((sortBy[0] as Descending<T>).Expression);
            for (int i = 1; i < sortBy.Count; i++)
            {
                r = sortBy[i] is Ascending<T> ?
                    r.Ascending((sortBy[i] as Ascending<T>).Expression) :
                    r.Descending((sortBy[i] as Descending<T>).Expression);
            }

            return r;
        }

        public async Task<List<T>> FindManyById(IEnumerable<ObjectId> ids, ReadAck? rc = null, ReadPref? rp = null, CancellationToken? ct = null)
        {
            var idList = ids.ToList();
            var collection = Collection;
            if (rc != null)
                collection = collection.WithReadConcern(rc?.ToReadConcern());
            if (rp != null)
                collection = collection.WithReadPreference(rp?.ToReadPreference());

            var filter = Builders<T>.Filter.In("_id", idList);
            return await (await collection.FindAsync(Context.Session, filter,
                cancellationToken: ct ?? CancellationToken.None)).ToListAsync();
        }
    }
}
