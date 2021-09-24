using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Infrastructure.Database
{
    public class MongoConfigurationSection
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
