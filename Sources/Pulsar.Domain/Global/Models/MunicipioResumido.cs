using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Global.Models
{
    public class MunicipioResumido
    {
        public ObjectId MunicipioId { get; set; }
        public long Codigo { get; set; }
        public string Nome { get; set; }
        public EstadoResumido Estado { get; set; }
    }
}
