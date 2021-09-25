using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Pulsar.Common;
using Pulsar.Common.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Database
{
    public class MongoContextFactory : IDbContextFactory
    {
        public IConfiguration Configuration { get; }
        private MongoConfigurationSection ConfigurationSection { get; }
        public MongoContextFactory(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.ConfigurationSection = configuration.GetSection("MongoDB")?.Get<MongoConfigurationSection>();
            if (this.ConfigurationSection?.ConnectionString == null)
                throw new InvalidOperationException("connection string was not provided");
            if (this.ConfigurationSection?.Database == null)
                throw new InvalidOperationException("database name was not provided");
        }
        public MongoContextFactory(MongoConfigurationSection configuration)
        {
            this.ConfigurationSection = configuration;
            if (this.ConfigurationSection?.ConnectionString == null)
                throw new InvalidOperationException("connection string was not provided");
            if (this.ConfigurationSection?.Database == null)
                throw new InvalidOperationException("database name was not provided");
        }
        public async Task<T> StartWithResponse<T>(Func<MongoContext, Task<T>> work,
            IsolationOptions? options = null,
            CancellationToken? cancellationToken = null,
            IClientSessionHandle currentSession = null
            )
        {
            if (options == null)
                options = new IsolationOptions();
            IMongoClient client = new MongoClient(EnableRetryWrites(ConfigurationSection.ConnectionString));
            var db = client.GetDatabase(ConfigurationSection.Database);
            IClientSessionHandle session = null;
            if (currentSession != null)
                session = currentSession;
            else
                session = await client.StartSessionAsync(new ClientSessionOptions()
                {
                    CausalConsistency = options.Value.EnableCasualConsistency,
                    DefaultTransactionOptions = new TransactionOptions(
                        readConcern: options.Value.Read?.ToReadConcern(),
                        readPreference: options.Value.Preference?.ToReadPreference(),
                        writeConcern: options.Value.Write?.ToWriteConcern(),
                        maxCommitTime: options.Value.MaxCommitTime)
                });

            try
            {
                if (options.Value.HandleOptimisticFailures)
                {
                    return await RetryOnOptimisticFailure(async () =>
                    {
                        if (options.Value.OpenTransaction)
                        {
                            return await session.WithTransactionAsync(async (s, ct) =>
                            {
                                var uow = new MongoContext(s, client, ct, db, options.Value);
                                return await work(uow);
                            }, cancellationToken: cancellationToken ?? CancellationToken.None);
                        }
                        else
                        {
                            SetUpClientAndDatabase(options, ref client, ref db);
                            var uow = new MongoContext(session, client, cancellationToken ?? CancellationToken.None, db, options.Value);
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
                            var uow = new MongoContext(s, client, ct, db, options.Value);
                            return await work(uow);
                        }, cancellationToken: cancellationToken ?? CancellationToken.None);
                    }
                    else
                    {
                        SetUpClientAndDatabase(options, ref client, ref db);
                        var uow = new MongoContext(null, client, cancellationToken ?? CancellationToken.None, db, options.Value);
                        return await work(uow);
                    }
                }
            }
            finally
            {
                if(currentSession == null)
                    session.Dispose();
            }
        }

        private string EnableRetryWrites(string connectionString)
        {
            if (connectionString.Contains("?retryWrites", StringComparison.InvariantCultureIgnoreCase) ||
               connectionString.Contains("&retryWrites", StringComparison.InvariantCultureIgnoreCase))
                return connectionString;

            if (!connectionString.Contains("?"))
                connectionString += "?retryWrites=true";
            else
                connectionString += "&retryWrites=true";

            return connectionString;
        }

        public async Task Start(Func<MongoContext, Task> work,
            IsolationOptions? options = null,
            CancellationToken? cancellationToken = null,
            IClientSessionHandle currentSession = null
            )
        {
            await StartWithResponse(async ctx =>
            {
                await work(ctx);
                return 0;
            }, options, cancellationToken, currentSession);
        }

        private void SetUpClientAndDatabase(IsolationOptions? options, ref IMongoClient client, ref IMongoDatabase db)
        {
            if (options.Value.Read != null)
            {
                client = client.WithReadConcern(options.Value.Read?.ToReadConcern());
            }
            if (options.Value.Write != null)
            {
                client = client.WithWriteConcern(options.Value.Write?.ToWriteConcern());
            }
            if (options.Value.Preference != null)
            {
                client = client.WithReadPreference(options.Value.Preference?.ToReadPreference());
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

        async Task<T> IDbContextFactory.StartWithResponse<T>(Func<IDbContext, Task<T>> work, IsolationOptions? options, CancellationToken? cancellationToken, 
            object currentSession)
        {
            return await StartWithResponse(async ctx =>
            {
                return await work(ctx);
            }, options, cancellationToken, currentSession as IClientSessionHandle);
        }

        async Task IDbContextFactory.Start(Func<IDbContext, Task> work, IsolationOptions? options, CancellationToken? cancellationToken, object currentSession)
        {
            await StartWithResponse(async ctx =>
            {
                await work(ctx);
                return 0;
            }, options, cancellationToken, currentSession as IClientSessionHandle);
        }
    }
}
