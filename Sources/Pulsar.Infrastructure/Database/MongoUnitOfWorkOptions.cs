using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Database
{
    public struct MongoUnitOfWorkOptions
    {
        public bool HandleOptimisticFailures { get; set; }
        public bool OpenTransaction { get; set; }
        public bool EnableCasualConsistency { get; set; }
        public TimeSpan? MaxCommitTime { get; set; }
        public ReadConcern ReadConcern { get; set; }
        public ReadPreference ReadPreference { get; set; }
        public WriteConcern WriteConcern { get; set; }

        public static readonly MongoUnitOfWorkOptions Stale = new MongoUnitOfWorkOptions()
        {
            ReadConcern = ReadConcern.Available,
            WriteConcern = WriteConcern.W1,
            ReadPreference = ReadPreference.Nearest
        };

        public static readonly MongoUnitOfWorkOptions PrimaryPreferred = new MongoUnitOfWorkOptions()
        {
            ReadConcern = ReadConcern.Available,
            WriteConcern = WriteConcern.W1,
            ReadPreference = ReadPreference.PrimaryPreferred
        };

        public static readonly MongoUnitOfWorkOptions Uncommitted = new MongoUnitOfWorkOptions()
        {
            ReadConcern = ReadConcern.Available,
            WriteConcern = WriteConcern.W1,
            ReadPreference = ReadPreference.Primary
        };

        public static readonly MongoUnitOfWorkOptions Committed = new MongoUnitOfWorkOptions()
        {
            ReadConcern = ReadConcern.Majority,
            WriteConcern = WriteConcern.WMajority,
            ReadPreference = ReadPreference.Primary
        };

        public MongoUnitOfWorkOptions WithTransaction() => new MongoUnitOfWorkOptions()
        {
            EnableCasualConsistency = this.EnableCasualConsistency,
            HandleOptimisticFailures = this.HandleOptimisticFailures,
            MaxCommitTime = this.MaxCommitTime,
            OpenTransaction = true,
            ReadConcern = this.ReadConcern,
            ReadPreference = this.ReadPreference,
            WriteConcern = this.WriteConcern
        };

        public MongoUnitOfWorkOptions WithOptmistic() => new MongoUnitOfWorkOptions()
        {
            EnableCasualConsistency = this.EnableCasualConsistency,
            HandleOptimisticFailures = true,
            MaxCommitTime = this.MaxCommitTime,
            OpenTransaction = this.OpenTransaction,
            ReadConcern = this.ReadConcern,
            ReadPreference = this.ReadPreference,
            WriteConcern = this.WriteConcern
        };

        public MongoUnitOfWorkOptions WithCasualConsistency() => new MongoUnitOfWorkOptions()
        {
            EnableCasualConsistency = true,
            HandleOptimisticFailures = this.HandleOptimisticFailures,
            MaxCommitTime = this.MaxCommitTime,
            OpenTransaction = this.OpenTransaction,
            ReadConcern = this.ReadConcern,
            ReadPreference = this.ReadPreference,
            WriteConcern = this.WriteConcern
        };

        public MongoUnitOfWorkOptions WithOptimisticTransaction() => new MongoUnitOfWorkOptions()
        {
            EnableCasualConsistency = this.EnableCasualConsistency,
            HandleOptimisticFailures = true,
            MaxCommitTime = this.MaxCommitTime,
            OpenTransaction = true,
            ReadConcern = this.ReadConcern,
            ReadPreference = this.ReadPreference,
            WriteConcern = this.WriteConcern
        };
    }
}
