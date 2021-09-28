using MongoDB.Bson;
using MongoDB.Driver;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Database
{
    public static class MongoExtensions
    {
        public static ReadConcern ToReadConcern(this ReadAck r) => r switch
        {
            ReadAck.Available => ReadConcern.Available,
            ReadAck.Default => ReadConcern.Default,
            ReadAck.Linearizable => ReadConcern.Linearizable,
            ReadAck.Local => ReadConcern.Local,
            ReadAck.Majority => ReadConcern.Majority,
            ReadAck.Snapshot => ReadConcern.Snapshot,
            _ => throw new InvalidOperationException()
        };
        public static WriteConcern ToWriteConcern(this WriteAck r) => r switch
        {
            WriteAck.Acknowledged => WriteConcern.Acknowledged,
            WriteAck.Unacknowledged => WriteConcern.Unacknowledged,
            WriteAck.W1 => WriteConcern.W1,
            WriteAck.W2 => WriteConcern.W2,
            WriteAck.W3 => WriteConcern.W3,
            WriteAck.WMajority => WriteConcern.WMajority,
            _ => throw new InvalidOperationException()
        };
        public static ReadPreference ToReadPreference(this ReadPref r) => r switch
        {
            ReadPref.Nearest => ReadPreference.Nearest,
            ReadPref.Primary => ReadPreference.Primary,
            ReadPref.PrimaryPreferred => ReadPreference.PrimaryPreferred,
            ReadPref.Secondary => ReadPreference.Secondary,
            ReadPref.SecondaryPreferred => ReadPreference.SecondaryPreferred,
            _ => throw new InvalidOperationException()
        };
        public static async Task<bool> CollectionExists(this IMongoDatabase db, string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            var collections = await db.ListCollectionsAsync(new ListCollectionsOptions { Filter = filter });
            return await collections.AnyAsync();
        }
    }
}
