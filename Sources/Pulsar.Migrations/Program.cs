using Pulsar.Domain.Especialidades.Models;
using Pulsar.Infrastructure.Database;
using Pulsar.Infrastructure.Migrations;
using System;
using System.Threading.Tasks;

namespace Pulsar.Migrations
{
    class Program
    {
        static async Task Main(string[] args)
        {
            MongoAutoMapper.Map(typeof(Especialidade).Assembly);
            await MongoMigrate.Run(typeof(Program).Assembly);
        }
    }
}
