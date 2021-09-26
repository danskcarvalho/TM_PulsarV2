using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Pulsar.Common.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Jobs
{
    public class JobModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Discriminator { get; set; }
        public BsonDocument Command { get; set; }
        public JobStatus Status { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedOn { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? StartedExecutionOn { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? EndedExecutionOn { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime ScheduledForExecution { get; set; }
        public JobErrorCategory? ErrorCategory { get; set; }
        public string ExceptionJson { get; set; }

        public bool MayNeedProcessing()
        {
            return Status == JobStatus.Pending ||
                (Status == JobStatus.Executing && StartedExecutionOn != null && DateTime.Now > StartedExecutionOn.Value.AddMilliseconds(JobConstants.ExecutingTimeout));
        }
    }
}
