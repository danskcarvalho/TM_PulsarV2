using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Pulsar.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Migrations
{
    public static class MongoMigrate
    {
        public static async Task Run(Assembly assembly)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .Build();

            var factory = new MongoUnitOfWorkFactory(configuration);
            var migrations = await factory.Start(async uow =>
            {
                return await GatherMigrations(assembly, uow);
            }, options: MongoUnitOfWorkOptions.Committed);
            //run migrations
            int number = 1;
            foreach (var mig in migrations)
            {
                var worker = new MigrationWorker(number, migrations.Count, mig, factory);
                await worker.Migrate();
            }
        }

        private static async Task<List<Type>> GatherMigrations(Assembly assembly, MongoUnitOfWork uow)
        {
            var allMigrationTypes = assembly.GetTypes().ToList();
            allMigrationTypes = allMigrationTypes.Where(t => IsMigrationType(t)).ToList();
            var orderedMigrations = allMigrationTypes.Select(t => (Type: t, Attribute: GetAttribute(t)))
                .OrderBy(t => t.Attribute.Version).ToList();

            await CreateMigrationsCollectionIfNotExists(uow);
            var migrations = await GetCurrentMigrations(uow);
            var allVersions = new HashSet<long>(migrations.Select(m => m.Version));

            List<Type> result = new List<Type>();
            foreach (var migrationTy in orderedMigrations)
            {
                if (!allVersions.Contains(migrationTy.Attribute.Version))
                    result.Add(migrationTy.Type);
            }

            return result;
        }

        private static MigrationAttribute GetAttribute(Type t)
        {
            return t.GetCustomAttribute<MigrationAttribute>();
        }

        private static bool IsMigrationType(Type t)
        {
            return t.IsClass && !t.IsGenericTypeDefinition && t.GetCustomAttributes<MigrationAttribute>().Any() && typeof(Migration).IsAssignableFrom(t);
        }

        private static async Task<List<MigrationModel>> GetCurrentMigrations(MongoUnitOfWork uow)
        {
            var collection = uow.GetCollection<MigrationModel>(MigrationConstants.CollectionName);
            return await (await collection.FindAsync(m => true)).ToListAsync();
        }

        private static async Task CreateMigrationsCollectionIfNotExists(MongoUnitOfWork uow)
        {
            //check for existence of collection _Migrations
            var filter = new BsonDocument("name", MigrationConstants.CollectionName);
            var collections = await uow.Database.ListCollectionsAsync(new ListCollectionsOptions { Filter = filter });
            var exists = await collections.AnyAsync();
            if (!exists)
                await uow.Database.CreateCollectionAsync(MigrationConstants.CollectionName);
            //creates unique index to ensure that version is always unique
            //indexes are indempotent
            var collection = uow.GetCollection<MigrationModel>(MigrationConstants.CollectionName);
            var keys = Builders<MigrationModel>.IndexKeys.Ascending(x => x.Version);
            await collection.Indexes.CreateOneAsync(new CreateIndexModel<MigrationModel>(keys, new CreateIndexOptions()
            {
                Unique = true,
                Name = MigrationConstants.VersionIsUniqueIndexName
            }));
        }
    }
}
