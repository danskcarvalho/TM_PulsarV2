﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Regioes.Models
{
    public class PaisResumido
    {
        public ObjectId PaisId { get; set; }
        public long Codigo { get; set; }
        public string Nome { get; set; }
    }
}