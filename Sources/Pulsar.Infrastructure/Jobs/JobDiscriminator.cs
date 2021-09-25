using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Pulsar.Common.Cqrs;
using Pulsar.Common.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Jobs
{
    public static class JobDiscriminator
    {
        private static Dictionary<string, Type> _DiscriminatorsToType = new Dictionary<string, Type>();
        private static bool _DiscriminatorsToTypeInitialized = false;

        private static Dictionary<string, Type> InitDiscriminatorsToType()
        {
            lock (_DiscriminatorsToType)
            {
                if (_DiscriminatorsToTypeInitialized)
                    return _DiscriminatorsToType;

                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (!assembly.FullName.Contains("Pulsar."))
                        continue;

                    foreach (var type in assembly.GetTypes())
                    {
                        if (!typeof(ICommand).IsAssignableFrom(type) || !type.IsClass || type.IsInterface)
                            continue;

                        var d = type.GetCustomAttribute<JobDiscriminatorAttribute>();
                        if(d != null && d.Discriminator != null)
                        {
                            if (_DiscriminatorsToType.ContainsKey(d.Discriminator))
                                throw new InvalidOperationException($"duplicated job discriminator '{d.Discriminator}'");
                            _DiscriminatorsToType.Add(d.Discriminator, type);
                        }
                    }
                }
                _DiscriminatorsToTypeInitialized = true;
                return _DiscriminatorsToType;
            }
        }

        public static Type GetType(string discriminator)
        {
            var d = InitDiscriminatorsToType();
            if (!d.ContainsKey(discriminator))
                return null;
            else
                return d[discriminator];
        }

        public static ICommand GetJob(string discriminator, BsonDocument bson)
        {
            var ty = GetType(discriminator);
            if (ty == null)
                throw new InvalidOperationException($"no type with discriminator '{discriminator}'");

            return (ICommand)BsonSerializer.Deserialize(bson, ty);
        }
    }
}
