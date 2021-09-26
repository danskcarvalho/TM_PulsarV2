using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Database
{
    public static class MongoAutoMapper
    {
        public static void Map(Assembly assembly)
        {
            var allModels = GetAllModels(assembly);
            var inheritanceGraph = BuildInheritanceGraph(allModels);

            var pack = new ConventionPack();
            pack.AddClassMapConvention("ReadOnlyPropertyShouldBeSerialized", c =>
            {
                var properties = c.ClassType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (var pi in properties)
                {
                    if (!pi.CanWrite)
                        c.MapProperty(pi.Name);
                }

            });

            pack.AddClassMapConvention("PolymorphicClasses", c =>
            {
                if (!inheritanceGraph.ContainsKey(c.ClassType))
                    return;
                var graph = inheritanceGraph[c.ClassType];
                if (graph.SuperClasses.Count != 0 || graph.BaseClasses.Count != 0)
                {
                    c.SetDiscriminator(c.ClassType.Name);
                    if (graph.SuperClasses.Count != 0 && graph.BaseClasses.Count == 0)
                        c.SetIsRootClass(true);
                }
                
            });

            pack.AddMemberMapConvention("DateShouldBeLocal", c =>
            {
                if (c.MemberType == typeof(DateTime))
                    c.SetSerializer(new DateTimeSerializer(DateTimeKind.Local));
                else if (c.MemberType == typeof(DateTime?))
                    c.SetSerializer(new NullableSerializer<DateTime>().WithSerializer(new DateTimeSerializer(DateTimeKind.Local)));
            });

            ConventionRegistry.Register(
               "PulsarConventions",
               pack,
               t => true);

            foreach (var ty in allModels)
            {
                RegisterClass(ty);
            }
        }

        private static void RegisterClass(Type ty)
        {
            var map = new BsonClassMap(ty);
            map.AutoMap();
            BsonClassMap.RegisterClassMap(map);
        }

        private static Dictionary<Type, (HashSet<Type>  BaseClasses, HashSet<Type> SuperClasses)> BuildInheritanceGraph(List<Type> allModels)
        {
            var edges = new HashSet<(Type SuperClass, Type BaseClass)>();

            foreach (var model in allModels)
            {
                if (IsValidBaseClass(model.BaseType))
                    edges.Add((model, model.BaseType));
            }

            bool changed = false;
            var newEdges = new HashSet<(Type SuperClass, Type BaseClass)>();
            do
            {
                changed = false;
                newEdges.Clear();
                foreach (var e1 in edges)
                {
                    foreach (var e2 in edges)
                    {
                        if (e1.SuperClass == e2.BaseClass)
                            newEdges.Add((e2.SuperClass, e1.BaseClass));
                    }
                }
                int previousSize = edges.Count;
                edges.UnionWith(newEdges);
                if (previousSize != edges.Count)
                    changed = true;
            } while (changed);

            var result = new Dictionary<Type, (HashSet<Type> BaseClasses, HashSet<Type> SuperClasses)>();
            foreach (var edge in edges)
            {
                if (!result.ContainsKey(edge.BaseClass))
                    result[edge.BaseClass] = (new(), new());
                if (!result.ContainsKey(edge.SuperClass))
                    result[edge.SuperClass] = (new(), new());

                result[edge.BaseClass].SuperClasses.Add(edge.SuperClass);
                result[edge.SuperClass].BaseClasses.Add(edge.BaseClass);
            }
            return result;
        }

        private static bool IsValidBaseClass(Type baseType)
        {
            return baseType != typeof(object) && baseType.FullName.Contains("Models.");
        }

        private static List<Type> GetAllModels(Assembly assembly)
        {
            List<Type> result = new();

            foreach (Type t in assembly.GetTypes())
            {
                if (t.IsClass && !t.IsGenericTypeDefinition && t.FullName.Contains("Models.") && !t.IsInterface)
                    result.Add(t);
            }
            return result;
        }
    }
}
