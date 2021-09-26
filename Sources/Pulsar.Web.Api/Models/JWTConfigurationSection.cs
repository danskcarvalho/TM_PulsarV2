using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulsar.Web.Api.Models
{
    public class JWTConfigurationSection
    {
        public TimeSpan ExpirationTime { get; set; }
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
