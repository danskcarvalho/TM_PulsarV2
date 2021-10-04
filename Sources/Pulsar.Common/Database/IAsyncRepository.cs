using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Common.Database
{
    public interface IAsyncRepository<T> where T : class
    {
        IAsyncRepository<TOther> Cast<TOther>() where TOther : class, T;
        Task InsertOne(T item, 
            bool autoFlush = false, 
            CancellationToken? ct = null);
        Task InsertMany(IEnumerable<T> items,
            bool autoFlush = false,
            CancellationToken? ct = null);
        Task UpdateOne(T item,
            bool autoFlush = false,
            CancellationToken? ct = null);
        Task DeleteOne(ObjectId id,
            bool autoFlush = false,
            CancellationToken? ct = null);
        Task<long> DeleteMany(Expression<Func<T, bool>> predicate,
            bool autoFlush = true,
            CancellationToken? ct = null);

        Task<long> UpdateMany(Expression<Func<T, bool>> predicate,
            Func<Update<T>, Update<T>> fields,
            bool autoFlush = true,
            CancellationToken? ct = null);

        Task<long> UpdateOne(Expression<Func<T, bool>> predicate,
            Func<Update<T>, Update<T>> fields,
            bool autoFlush = true,
            CancellationToken? ct = null);
        Task<T> FindOneById(ObjectId id,
            bool noSession = false,
            bool noCache = false,
            CancellationToken? ct = null);
        Task<List<T>> FindManyById(IEnumerable<ObjectId> ids,
            bool noSession = false,
            bool noCache = false,
            CancellationToken? ct = null);

        Task<TProjection> FindOneById<TProjection>(ObjectId id,
            Expression<Func<T, TProjection>> projection,
            bool noSession = false,
            CancellationToken? ct = null);
        Task<List<TProjection>> FindManyById<TProjection>(IEnumerable<ObjectId> ids,
            Expression<Func<T, TProjection>> projection,
            bool noSession = false,
            CancellationToken? ct = null);
        Task<bool> CheckOneById(ObjectId id,
            bool noSession = false,
            CancellationToken? ct = null);
        Task<List<bool>> CheckManyById(IEnumerable<ObjectId> ids,
            bool noSession = false,
            CancellationToken? ct = null);

        Task<T> FindOne(Expression<Func<T, bool>> predicate,
            bool noSession = false,
            CancellationToken? ct = null);
        Task<TProjection> FindOne<TProjection>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TProjection>> projection,
            bool noSession = false,
            CancellationToken? ct = null);

        Task<List<T>> FindMany(Expression<Func<T, bool>> predicate, 
            int? skip = null,
            int? limit = null,
            List<Ordering<T>> sortBy = null,
            bool noSession = false,
            CancellationToken? ct = null);

        Task<List<TProjection>> FindMany<TProjection>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TProjection>> projection,
            int? skip = null,
            int? limit = null,
            List<Ordering<T>> sortBy = null,
            bool noSession = false,
            CancellationToken? ct = null);
    }
}
