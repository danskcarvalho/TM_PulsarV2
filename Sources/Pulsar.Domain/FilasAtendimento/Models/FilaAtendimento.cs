using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Comum;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.FilasAtendimento.Models
{
    public class FilaAtendimento
    {
        public ObjectId Id { get; set; }
        public DateTime Data { get; set; }
        public StatusFilaAtendimento Status { get; set; }
        public EstabelecimentoResumido Estabelecimento { get; set; }
        public UsuarioResumido Profissional { get; set; }
        public List<FilaAtendimentoItem> Items { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
