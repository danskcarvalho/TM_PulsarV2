using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common
{
    public static class Extensions
    {
        public static async Task<bool> CollectionExists(this IMongoDatabase db, string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            var collections = await db.ListCollectionsAsync(new ListCollectionsOptions { Filter = filter });
            return await collections.AnyAsync();
        }
        public static T FromBson<T>(this string str)
        {
            return BsonSerializer.Deserialize<T>(str);
        }
        public static string ToBson<T>(this T obj)
        {
            return obj.ToBsonDocument().ToJson();
        }

        public static IEnumerable<List<T>> Partition<T>(this IEnumerable<T> e, int partitionSize)
        {
            List<T> list = null;
            foreach (var item in e)
            {
                if (list == null)
                    list = new List<T>();

                if(list.Count >= partitionSize)
                {
                    yield return list;
                    list = new List<T>();
                }

                list.Add(item);
            }

            if (list.Count != 0)
                yield return list;
        }
    }
}
