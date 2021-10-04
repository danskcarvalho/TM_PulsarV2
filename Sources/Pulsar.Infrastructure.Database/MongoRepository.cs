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
        private Dictionary<ObjectId, T> _Cache = new Dictionary<ObjectId, T>();
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

        async Task IAsyncRepository<T>.DeleteOne(ObjectId id, bool autoFlush, CancellationToken? ct)
        {
            if (!autoFlush)
            {
                Context.AddFlushAction(() => ((IAsyncRepository<T>)this).DeleteOne(id, true, ct));
                return;
            }
            var filter = Builders<T>.Filter.Eq("_id", id);
            await Collection.DeleteOneAsync(Context.Session, filter,
                cancellationToken: ct ?? CancellationToken.None);
        }

        async Task<T> IAsyncRepository<T>.FindOneById(ObjectId id, bool noSession, bool noCache, CancellationToken? ct)
        {
            if (!noCache)
            {
                if (_Cache.ContainsKey(id))
                    return _Cache[id];
            }

            var filter = Builders<T>.Filter.Eq("_id", id);
            T r = null;
            if (noSession)
                r = await (await Collection.FindAsync(filter, new FindOptions<T> { Limit = 1 },
                    cancellationToken: ct ?? CancellationToken.None)).FirstOrDefaultAsync();
            else

                r = await (await Collection.FindAsync(Context.Session, filter, new FindOptions<T> { Limit = 1 },
                    cancellationToken: ct ?? CancellationToken.None)).FirstOrDefaultAsync();

            if (!noCache)
                _Cache[id] = r;
            return r;
        }

        async Task IAsyncRepository<T>.InsertMany(IEnumerable<T> items, bool autoFlush, CancellationToken? ct)
        {
            if (!autoFlush)
            {
                Context.AddInsert(typeof(T), items, ct, (o, c) => ((IAsyncRepository<T>)this).InsertMany(o.Cast<T>(), true, ct));
                return;
            }

            await Collection.InsertManyAsync(Context.Session, items,
                cancellationToken: ct ?? CancellationToken.None);
        }

        async Task IAsyncRepository<T>.InsertOne(T item, bool autoFlush, CancellationToken? ct)
        {
            if (!autoFlush)
            {
                Context.AddInsert(typeof(T), item, ct, (o, c) => ((IAsyncRepository<T>)this).InsertMany(o.Cast<T>(), true, ct));
                return;
            }

            await Collection.InsertOneAsync(Context.Session, item,
                cancellationToken: ct ?? CancellationToken.None);
        }

        async Task IAsyncRepository<T>.UpdateOne(T item, bool autoFlush, CancellationToken? ct)
        {
            if (!autoFlush)
            {
                Context.AddFlushAction(() => ((IAsyncRepository<T>)this).UpdateOne(item, true, ct));
                return;
            }

            var filter = Builders<T>.Filter.Eq("_id", (ObjectId)_IdProperty.GetValue(item));
            await Collection.FindOneAndReplaceAsync(Context.Session, filter, item,
                cancellationToken: ct ?? CancellationToken.None);
        }

        async Task<T> IAsyncRepository<T>.FindOne(Expression<Func<T, bool>> predicate, bool noSession, CancellationToken? ct)
        {
            if (noSession)
                return await (await Collection.FindAsync(predicate, new FindOptions<T>
                {
                    Limit = 1
                }, cancellationToken: ct ?? CancellationToken.None)).FirstOrDefaultAsync();
            else
                return await (await Collection.FindAsync(Context.Session, predicate, new FindOptions<T>
                {
                    Limit = 1
                }, cancellationToken: ct ?? CancellationToken.None)).FirstOrDefaultAsync();
        }

        async Task<List<T>> IAsyncRepository<T>.FindMany(Expression<Func<T, bool>> predicate,
            int? skip,
            int? limit,
            List<Ordering<T>> sortBy,
            bool noSession,
            CancellationToken? ct)
        {
            var findOptions = new FindOptions<T>();
            findOptions.Skip = skip;
            findOptions.Limit = limit;
            if (sortBy != null && sortBy.Count != 0)
                findOptions.Sort = BuildSortDefinition(sortBy);

            if (noSession)
                return await (await Collection.FindAsync(predicate, options: findOptions,
                    cancellationToken: ct ?? CancellationToken.None)).ToListAsync();
            else
                return await (await Collection.FindAsync(Context.Session, predicate, options: findOptions,
                    cancellationToken: ct ?? CancellationToken.None)).ToListAsync();
        }

        async Task<List<TProjection>> IAsyncRepository<T>.FindMany<TProjection>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TProjection>> projection,
            int? skip,
            int? limit,
            List<Ordering<T>> sortBy,
            bool noSession,
            CancellationToken? ct)
        {
            var findOptions = new FindOptions<T, TProjection>();
            findOptions.Skip = skip;
            findOptions.Limit = limit;
            var projectionDef = Builders<T>.Projection.Expression(projection);
            findOptions.Projection = projectionDef;
            if (sortBy != null && sortBy.Count != 0)
                findOptions.Sort = BuildSortDefinition(sortBy);

            if (noSession)
                return await (await Collection.FindAsync<TProjection>(predicate, options: findOptions,
                    cancellationToken: ct ?? CancellationToken.None)).ToListAsync();
            else
                return await (await Collection.FindAsync<TProjection>(Context.Session, predicate, options: findOptions,
                    cancellationToken: ct ?? CancellationToken.None)).ToListAsync();
        }

        async Task<long> IAsyncRepository<T>.DeleteMany(Expression<Func<T, bool>> predicate, bool autoFlush, CancellationToken? ct)
        {
            if (!autoFlush)
            {
                Context.AddFlushAction(() => ((IAsyncRepository<T>)this).DeleteMany(predicate, true, ct));
                return -1;
            }

            return (await Collection.DeleteManyAsync(Context.Session, predicate,
                cancellationToken: ct ?? CancellationToken.None)).DeletedCount;
        }

        async Task<long> IAsyncRepository<T>.UpdateMany(Expression<Func<T, bool>> predicate, Func<Update<T>, Update<T>> fields, bool autoFlush, CancellationToken? ct)
        {
            if (!autoFlush)
            {
                Context.AddFlushAction(() => ((IAsyncRepository<T>)this).UpdateMany(predicate, fields, true, ct));
                return -1;
            }

            var upd = fields(new MongoUpdate<T>(Builders<T>.Update)) as MongoUpdate<T>;
            return (await Collection.UpdateManyAsync(Context.Session, predicate, upd.Definition,
                cancellationToken: ct ?? CancellationToken.None)).ModifiedCount;
        }

        async Task<long> IAsyncRepository<T>.UpdateOne(Expression<Func<T, bool>> predicate, Func<Update<T>, Update<T>> fields, bool autoFlush, CancellationToken? ct)
        {
            if (!autoFlush)
            {
                Context.AddFlushAction(() => ((IAsyncRepository<T>)this).UpdateOne(predicate, fields, true, ct));
                return -1;
            }

            var upd = fields(new MongoUpdate<T>(Builders<T>.Update)) as MongoUpdate<T>;
            return (await Collection.UpdateOneAsync(Context.Session, predicate, upd.Definition,
                cancellationToken: ct ?? CancellationToken.None)).ModifiedCount;
        }

        async Task<List<T>> IAsyncRepository<T>.FindManyById(IEnumerable<ObjectId> ids, bool noSession, bool noCache, CancellationToken? ct)
        {
            if (!noCache)
            {
                if (ids.All(x => _Cache.ContainsKey(x)))
                    return ids.Select(x => _Cache[x]).ToList();
            }

            var idList = ids.ToList();
            var filter = Builders<T>.Filter.In("_id", idList);
            List<T> r = null;
            if (noSession)
                r = await (await Collection.FindAsync(filter,
                    cancellationToken: ct ?? CancellationToken.None)).ToListAsync();
            else
                r = await (await Collection.FindAsync(Context.Session, filter,
                    cancellationToken: ct ?? CancellationToken.None)).ToListAsync();

            if (!noCache)
            {
                foreach (var item in r)
                    _Cache[(ObjectId)_IdProperty.GetValue(item)] = item;
            }
            return r;
        }

        async Task<TProjection> IAsyncRepository<T>.FindOneById<TProjection>(ObjectId id, Expression<Func<T, TProjection>> projection, bool noSession, CancellationToken? ct)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            var projectionDef = Builders<T>.Projection.Expression(projection);

            if (noSession)
                return await (await Collection.FindAsync<TProjection>(filter, new FindOptions<T, TProjection> { Limit = 1, Projection = projectionDef },
                    cancellationToken: ct ?? CancellationToken.None)).FirstOrDefaultAsync();
            else
                return await (await Collection.FindAsync<TProjection>(Context.Session, filter, new FindOptions<T, TProjection> { Limit = 1, Projection = projectionDef },
                    cancellationToken: ct ?? CancellationToken.None)).FirstOrDefaultAsync();
        }

        async Task<List<TProjection>> IAsyncRepository<T>.FindManyById<TProjection>(IEnumerable<ObjectId> ids, Expression<Func<T, TProjection>> projection, bool noSession, CancellationToken? ct)
        {
            var idList = ids.ToList();
            var filter = Builders<T>.Filter.In("_id", idList);
            var projectionDef = Builders<T>.Projection.Expression(projection);
            if (noSession)
                return await (await Collection.FindAsync(filter, new FindOptions<T, TProjection> { Projection = projectionDef },
                    cancellationToken: ct ?? CancellationToken.None)).ToListAsync();
            else
                return await (await Collection.FindAsync(Context.Session, filter, new FindOptions<T, TProjection> { Projection = projectionDef },
                    cancellationToken: ct ?? CancellationToken.None)).ToListAsync();
        }

        async Task<bool> IAsyncRepository<T>.CheckOneById(ObjectId id, bool noSession, CancellationToken? ct)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            var projectionDef = Builders<T>.Projection.Include("_id");
            T r = null;
            if (noSession)
                r = await (await Collection.FindAsync(filter, new FindOptions<T> { Limit = 1, Projection = projectionDef },
                    cancellationToken: ct ?? CancellationToken.None)).FirstOrDefaultAsync();
            else
                r = await (await Collection.FindAsync(Context.Session, filter, new FindOptions<T> { Limit = 1, Projection = projectionDef },
                    cancellationToken: ct ?? CancellationToken.None)).FirstOrDefaultAsync();
            return r != default(T);
        }

        async Task<List<bool>> IAsyncRepository<T>.CheckManyById(IEnumerable<ObjectId> ids, bool noSession, CancellationToken? ct)
        {
            var idList = ids.ToList();
            var filter = Builders<T>.Filter.In("_id", idList);
            var projectionDef = Builders<T>.Projection.Include("_id");
            List<T> r = null;
            if (noSession)
                r = await(await Collection.FindAsync(filter, new FindOptions<T> { Projection = projectionDef },
                    cancellationToken: ct ?? CancellationToken.None)).ToListAsync();
            else
                r = await (await Collection.FindAsync(Context.Session, filter, new FindOptions<T> { Projection = projectionDef },
                    cancellationToken: ct ?? CancellationToken.None)).ToListAsync();
            HashSet<ObjectId> found = new HashSet<ObjectId>();
            found.UnionWith(r.Select(x => (ObjectId)x.GetType().GetProperty("Id").GetValue(x)));
            return idList.Select(x => found.Contains(x)).ToList();
        }

        async Task<TProjection> IAsyncRepository<T>.FindOne<TProjection>(Expression<Func<T, bool>> predicate, Expression<Func<T, TProjection>> projection, bool noSession, CancellationToken? ct)
        {
            var findOptions = new FindOptions<T, TProjection>();
            findOptions.Limit = 1;
            var projectionDef = Builders<T>.Projection.Expression(projection);
            findOptions.Projection = projectionDef;

            if (noSession)
                return await (await Collection.FindAsync<TProjection>(predicate, options: findOptions,
                    cancellationToken: ct ?? CancellationToken.None)).FirstOrDefaultAsync();
            else
                return await (await Collection.FindAsync<TProjection>(Context.Session, predicate, options: findOptions,
                    cancellationToken: ct ?? CancellationToken.None)).FirstOrDefaultAsync();
        }

        IAsyncRepository<TOther> IAsyncRepository<T>.Cast<TOther>()
        {
            return new CastMongoRepository<TOther>(Context, CollectionName);
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
    }

    class CastMongoRepository<T> : MongoRepository<T> where T : class
    {
        private string _CollectionName = null;
        public CastMongoRepository(MongoContext ctx, string collectionName) : base(ctx)
        {
            _CollectionName = collectionName;
        }

        protected override string CollectionName => _CollectionName;
    }
}
