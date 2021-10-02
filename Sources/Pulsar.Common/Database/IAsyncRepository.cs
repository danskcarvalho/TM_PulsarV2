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
        IQueryable<T> AsQueryable(ReadAck? rc = null, ReadPref? rp = null);
        Task InsertOne(T item, 
            WriteAck? wc = null, 
            CancellationToken? ct = null);
        Task InsertMany(IEnumerable<T> items, 
            WriteAck? wc = null, 
            CancellationToken? ct = null);
        Task UpdateOne(T item, 
            WriteAck? wc = null, 
            CancellationToken? ct = null);
        Task DeleteOne(ObjectId id, 
            WriteAck? wc = null, 
            CancellationToken? ct = null);
        Task<long> DeleteMany(Expression<Func<T, bool>> predicate,
            WriteAck? wc = null,
            CancellationToken? ct = null);

        Task<long> UpdateMany(Expression<Func<T, bool>> predicate,
            object fields,
            WriteAck? wc = null,
            CancellationToken? ct = null);

        Task<long> UpdateOne(Expression<Func<T, bool>> predicate,
            object fields,
            WriteAck? wc = null,
            CancellationToken? ct = null);
        Task<T> FindOneById(ObjectId id, 
            ReadAck? rc = null, 
            ReadPref? rp = null, 
            CancellationToken? ct = null);
        Task<List<T>> FindManyById(IEnumerable<ObjectId> ids,
            ReadAck? rc = null,
            ReadPref? rp = null,
            CancellationToken? ct = null);

        Task<TProjection> FindOneById<TProjection>(ObjectId id,
            Expression<Func<T, TProjection>> projection,
            ReadAck? rc = null,
            ReadPref? rp = null,
            CancellationToken? ct = null);
        Task<List<TProjection>> FindManyById<TProjection>(IEnumerable<ObjectId> ids,
            Expression<Func<T, TProjection>> projection,
            ReadAck? rc = null,
            ReadPref? rp = null,
            CancellationToken? ct = null);
        Task<bool> CheckOneById(ObjectId id,
            ReadAck? rc = null,
            ReadPref? rp = null,
            CancellationToken? ct = null);
        Task<List<bool>> CheckManyById(IEnumerable<ObjectId> ids,
            ReadAck? rc = null,
            ReadPref? rp = null,
            CancellationToken? ct = null);

        Task<T> FindOne(Expression<Func<T, bool>> predicate, 
            ReadAck? rc = null, 
            ReadPref? rp = null, 
            CancellationToken? ct = null);
        Task<TProjection> FindOne<TProjection>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TProjection>> projection,
            ReadAck? rc = null,
            ReadPref? rp = null,
            CancellationToken? ct = null);

        Task<List<T>> FindMany(Expression<Func<T, bool>> predicate, 
            int? skip = null,
            int? limit = null,
            List<Ordering<T>> sortBy = null,
            ReadAck? rc = null, 
            ReadPref? rp = null, 
            CancellationToken? ct = null);

        Task<List<TProjection>> FindMany<TProjection>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TProjection>> projection,
            int? skip = null,
            int? limit = null,
            List<Ordering<T>> sortBy = null,
            ReadAck? rc = null,
            ReadPref? rp = null,
            CancellationToken? ct = null);
    }
}
