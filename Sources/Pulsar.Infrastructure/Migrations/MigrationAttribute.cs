using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Migrations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class MigrationAttribute : Attribute
    {
        public long Version { get; }
        public bool RequiresTransaction { get; set; }
        public MigrationAttribute(long version)
        {
            this.Version = version;
        }
    }
}
