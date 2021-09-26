using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulsar.Web.Api.Models
{
    public class CurrentUser
    {
        public ObjectId Id { get; set; }
        public ObjectId? RedeEstabelecimentoId { get; set; }
        public ObjectId? EstabelecimentoId { get; set; }
    }
}
