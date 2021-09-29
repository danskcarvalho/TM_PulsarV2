using MongoDB.Bson;
using Pulsar.Domain.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Pastas.Models
{
    public class Pasta
    {
        public ObjectId Id { get; set; }
        public DataRegistro Registro { get; set; }
        public List<PastaArquivo> Arquivos { get; set; }
    }
}
