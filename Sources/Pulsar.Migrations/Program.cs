using Pulsar.Infrastructure.Migrations;
using System;
using System.Threading.Tasks;

namespace Pulsar.Migrations
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await MongoMigrate.Run(typeof(Program).Assembly);
        }
    }
}
