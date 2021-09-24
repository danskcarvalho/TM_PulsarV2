using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Migrations
{
    static class MigrationConstants
    {
        public const string CollectionName = "_Migrations";
        public const string VersionIsUniqueIndexName = "_uq_migrations_version";
    }
}
