using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulsar.Web.Api.Models
{
    public class UserClaims
    {
        public ObjectId Id { get; set; }
        public string Role { get; set; }
    }
}
