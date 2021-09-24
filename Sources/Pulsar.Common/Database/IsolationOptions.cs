using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Database
{
    public struct IsolationOptions
    {
        public bool HandleOptimisticFailures { get; set; }
        public bool OpenTransaction { get; set; }
        public bool EnableCasualConsistency { get; set; }
        public TimeSpan? MaxCommitTime { get; set; }
        public ReadAck? Read { get; set; }
        public ReadPref? Preference { get; set; }
        public WriteAck? Write { get; set; }

        public static readonly IsolationOptions Stale = new IsolationOptions()
        {
            Read = ReadAck.Available,
            Write = WriteAck.W1,
            Preference = ReadPref.Nearest
        };

        public static readonly IsolationOptions PrimaryPreferred = new IsolationOptions()
        {
            Read = ReadAck.Available,
            Write = WriteAck.W1,
            Preference = ReadPref.PrimaryPreferred
        };

        public static readonly IsolationOptions Uncommitted = new IsolationOptions()
        {
            Read = ReadAck.Available,
            Write = WriteAck.W1,
            Preference = ReadPref.Primary
        };

        public static readonly IsolationOptions Committed = new IsolationOptions()
        {
            Read = ReadAck.Majority,
            Write = WriteAck.WMajority,
            Preference = ReadPref.Primary
        };

        public IsolationOptions WithTransaction() => new IsolationOptions()
        {
            EnableCasualConsistency = this.EnableCasualConsistency,
            HandleOptimisticFailures = this.HandleOptimisticFailures,
            MaxCommitTime = this.MaxCommitTime,
            OpenTransaction = true,
            Read = this.Read,
            Preference = this.Preference,
            Write = this.Write
        };

        public IsolationOptions WithOptmistic() => new IsolationOptions()
        {
            EnableCasualConsistency = this.EnableCasualConsistency,
            HandleOptimisticFailures = true,
            MaxCommitTime = this.MaxCommitTime,
            OpenTransaction = this.OpenTransaction,
            Read = this.Read,
            Preference = this.Preference,
            Write = this.Write
        };

        public IsolationOptions WithCasualConsistency() => new IsolationOptions()
        {
            EnableCasualConsistency = true,
            HandleOptimisticFailures = this.HandleOptimisticFailures,
            MaxCommitTime = this.MaxCommitTime,
            OpenTransaction = this.OpenTransaction,
            Read = this.Read,
            Preference = this.Preference,
            Write = this.Write
        };

        public IsolationOptions WithOptimisticTransaction() => new IsolationOptions()
        {
            EnableCasualConsistency = this.EnableCasualConsistency,
            HandleOptimisticFailures = true,
            MaxCommitTime = this.MaxCommitTime,
            OpenTransaction = true,
            Read = this.Read,
            Preference = this.Preference,
            Write = this.Write
        };
    }
}
