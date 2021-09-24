using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Pulsar.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Database
{
    public class MongoUnitOfWorkFactory
    {
        public IConfiguration Configuration { get; }
        private MongoConfigurationSection ConfigurationSection { get; }
        public MongoUnitOfWorkFactory(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.ConfigurationSection = configuration.GetSection("MongoDB")?.Get<MongoConfigurationSection>();
            if (this.ConfigurationSection?.ConnectionString == null)
                throw new InvalidOperationException("connection string was not provided");
            if (this.ConfigurationSection?.Database == null)
                throw new InvalidOperationException("database name was not provided");
        }
        public MongoUnitOfWorkFactory(MongoConfigurationSection configuration)
        {
            this.ConfigurationSection = configuration;
            if (this.ConfigurationSection?.ConnectionString == null)
                throw new InvalidOperationException("connection string was not provided");
            if (this.ConfigurationSection?.Database == null)
                throw new InvalidOperationException("database name was not provided");
        }
        public async Task<T> Start<T>(Func<MongoUnitOfWork, Task<T>> work,
            MongoUnitOfWorkOptions? options = null,
            CancellationToken? cancellationToken = null,
            IClientSessionHandle currentSession = null
            )
        {
            if (options == null)
                options = new MongoUnitOfWorkOptions();
            IMongoClient client = new MongoClient(ConfigurationSection.ConnectionString);
            var db = client.GetDatabase(ConfigurationSection.Database);
            IClientSessionHandle session = null;
            if (currentSession != null)
                session = currentSession;
            if (options.Value.EnableCasualConsistency || options.Value.OpenTransaction)
                session = await client.StartSessionAsync(new ClientSessionOptions()
                {
                    CausalConsistency = options.Value.EnableCasualConsistency,
                    DefaultTransactionOptions = new TransactionOptions(
                        readConcern: options.Value.ReadConcern,
                        readPreference: options.Value.ReadPreference,
                        writeConcern: options.Value.WriteConcern,
                        maxCommitTime: options.Value.MaxCommitTime)
                });

            if (options.Value.HandleOptimisticFailures)
            {
                return await RetryOnOptimisticFailure(async () =>
                {
                    if (options.Value.OpenTransaction)
                    {
                        return await session.WithTransactionAsync(async (s, ct) =>
                        {
                            var uow = new MongoUnitOfWork(s, client, ct, db, options.Value);
                            return await work(uow);
                        }, cancellationToken: cancellationToken ?? CancellationToken.None);
                    }
                    else
                    {
                        SetUpClientAndDatabase(options, ref client, ref db);
                        var uow = new MongoUnitOfWork(null, client, cancellationToken ?? CancellationToken.None, db, options.Value);
                        return await work(uow);
                    }
                });
            }
            else
            {
                if (options.Value.OpenTransaction)
                {
                    return await session.WithTransactionAsync(async (s, ct) =>
                    {
                        var uow = new MongoUnitOfWork(s, client, ct, db, options.Value);
                        return await work(uow);
                    }, cancellationToken: cancellationToken ?? CancellationToken.None);
                }
                else
                {
                    SetUpClientAndDatabase(options, ref client, ref db);
                    var uow = new MongoUnitOfWork(null, client, cancellationToken ?? CancellationToken.None, db, options.Value);
                    return await work(uow);
                }
            }
        }

        private void SetUpClientAndDatabase(MongoUnitOfWorkOptions? options, ref IMongoClient client, ref IMongoDatabase db)
        {
            if (options.Value.ReadConcern != null)
            {
                client = client.WithReadConcern(options.Value.ReadConcern);
            }
            if (options.Value.WriteConcern != null)
            {
                client = client.WithWriteConcern(options.Value.WriteConcern);
            }
            if (options.Value.ReadPreference != null)
            {
                client = client.WithReadPreference(options.Value.ReadPreference);
            }
            db = client.GetDatabase(ConfigurationSection.Database);
        }

        private async Task<T> RetryOnOptimisticFailure<T>(Func<Task<T>> action)
        {
            Random rng = null;
            int maxWait = 1000;
            int retries = 0;

            while (true)
            {
                try
                {
                    return await action();
                }
                catch (OptimisticException)
                {
                    if (retries >= Constants.MaxRetriesOnOptimisticFailure)
                        throw;

                    if (rng == null)
                        rng = new Random();
                    int wait = (int)(rng.NextDouble() * maxWait);
                    wait = Math.Max(wait, 150);
                    await Task.Delay(wait);
                    retries++;
                    maxWait *= 2;
                }
            }
        }
    }
}
