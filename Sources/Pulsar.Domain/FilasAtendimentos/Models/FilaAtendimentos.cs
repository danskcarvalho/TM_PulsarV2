using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Common;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.FilasAtendimentos.Models
{
    public class FilaAtendimentos
    {
        public FilaAtendimentos()
        {
        }

        public FilaAtendimentos(Usuario usuarioLogado, Estabelecimento estabelecimento, Usuario profissional, DateTime data) : this()
        {
            Id = ObjectId.GenerateNewId();
            Data = data;
            Status = StatusFilaAtendimento.Aberta;
            EstabelecimentoId = estabelecimento.Id;
            ProfissionalId = profissional.Id;
            Items = new List<FilaAtendimentosItem>();
            DataRegistro = DataRegistro.CriadoHoje(usuarioLogado.Id);
        }

        public ObjectId Id { get; set; }
        public DateTime Data { get; set; }
        public StatusFilaAtendimento Status { get; set; }
        public ObjectId EstabelecimentoId { get; set; }
        public ObjectId ProfissionalId { get; set; }
        public List<FilaAtendimentosItem> Items { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
