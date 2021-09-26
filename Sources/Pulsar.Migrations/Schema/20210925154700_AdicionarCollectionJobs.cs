using Pulsar.Infrastructure.Migrations;
using System.Threading.Tasks;
using Pulsar.Common;
using Pulsar.Infrastructure;
using Pulsar.Infrastructure.Jobs;
using MongoDB.Driver;
using Pulsar.Infrastructure.Database;

namespace Pulsar.Migrations.Schema
{
    [Migration(20210925154700)]
    public class AdicionarCollectionJobs : Migration
    {
        public override async Task Up()
        {
            if (!(await Database.CollectionExists(Constants.CollectionNames.Jobs)))
                await Database.CreateCollectionAsync(Constants.CollectionNames.Jobs);

            var collection = Database.GetCollection<JobModel>(Constants.CollectionNames.Jobs);

            var ix_Status_ScheduledForExecution = Builders<JobModel>.IndexKeys
                .Ascending(j => j.Status)
                .Ascending(j => j.ScheduledForExecution);
            collection.Indexes.CreateOne(new MongoDB.Driver.CreateIndexModel<JobModel>(ix_Status_ScheduledForExecution, new CreateIndexOptions()
            {
                Name = "ix_Status_ScheduledForExecution"
            }));
        }
    }
}
