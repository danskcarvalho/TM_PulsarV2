using MongoDB.Driver;
using Newtonsoft.Json;
using Pulsar.Common.Database;
using Pulsar.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Migrations
{
    class MigrationWorker : MongoWorker
    {
        private int MigrationNumber { get; }
        private int TotalMigrations { get; }
        private Type MigrationType { get; } 
        public MigrationWorker(
            int migrationNumber,
            int totalMigrations,
            Type migrationType,
            MongoContextFactory factory) : base(factory)
        {
            this.MigrationNumber = migrationNumber;
            this.TotalMigrations = totalMigrations;
            this.MigrationType = migrationType;
        }

        public async Task Migrate()
        {
            var startTransaction = GetRequiresTransaction(MigrationType);
            var options = startTransaction ? IsolationOptions.Committed.WithTransaction() : IsolationOptions.Committed;
            await Factory.Start(async ctx =>
            {
                var migration = Activator.CreateInstance(MigrationType) as Migration;
                if (migration == null)
                    throw new InvalidOperationException("invalid migration type");
                migration.Set(ctx.Client, ctx.Database);

                var model = new MigrationModel()
                {
                    CreatedOn = DateTime.Now,
                    Name = MigrationType.Name,
                    Version = GetVersion(MigrationType)
                };
                Console.WriteLine($"[{MigrationNumber}/{TotalMigrations}] executing {model.Version}:{MigrationType.Name}");
                //insert into the collection _Migrations
                var collection = ctx.GetCollection<MigrationModel>(MigrationConstants.CollectionName);
                await collection.InsertOneAsync(model);

                try
                {
                    await migration.Up();
                }
                catch(Exception e)
                {
                    PrintRed($"migration {model.Version}:{MigrationType.Name} failed with exception {e.GetType().FullName}");
                    if (!startTransaction)
                        PrintRed($"migration {model.Version}:{MigrationType.Name} did not run under a transaction");
                    PrintRed(ToJson(e));
                    //undo insertion into collection _Migrations
                    if (!startTransaction)
                    {
                        try
                        {
                            await collection.DeleteOneAsync(p => p.Version == model.Version);
                        }
                        catch
                        {
                            PrintRed($"failed to completely undo migration {model.Version}:{MigrationType.Name}");
                        }
                    }
                    throw;
                }
            }, options: options);
        }

        private string ToJson(Exception e)
        {
            try
            {
                return JsonConvert.SerializeObject(e);
            }
            catch
            {
                return JsonConvert.SerializeObject(new
                {
                    e.Message,
                    e.StackTrace
                });
            }
        }
        private void PrintRed(string msg)
        {
            var previousForegroundColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg);
            }
            finally
            {
                Console.ForegroundColor = previousForegroundColor;
            }
        }
        private long GetVersion(Type migrationType)
        {
            var attr = migrationType
                .GetCustomAttributes(false)
                .Where(attr => attr is MigrationAttribute).Select(attr => attr as MigrationAttribute).First();
            return attr.Version;
        }
        private bool GetRequiresTransaction(Type migrationType)
        {
            var attr = migrationType
                .GetCustomAttributes(false)
                .Where(attr => attr is MigrationAttribute).Select(attr => attr as MigrationAttribute).First();
            return attr.RequiresTransaction;
        }
    }
}
