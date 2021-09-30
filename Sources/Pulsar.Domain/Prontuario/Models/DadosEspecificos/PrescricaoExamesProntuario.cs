using MongoDB.Bson;
using Pulsar.Domain.Atendimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuario.Models
{
    public class PrescricaoExamesProntuario : ProntuarioDados
    {
        public List<ExameItem> Items { get; set; }
    }
}
