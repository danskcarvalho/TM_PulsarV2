using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Notificacoes.Models
{
    public class Notificacao
    {
        public ObjectId Id { get; set; }
        public ObjectId UsuarioId { get; set; }
        public ObjectId? EstabelecimentoId { get; set; }
        public ObjectId? RedeEstabelecimentoId { get; set; }
        public NotificacaoTipo Tipo { get; set; }
        public string Mensagem { get; set; }
        public BsonDocument Parametros { get; set; }
        public bool Esconder { get; set; }
        public DataRegistro DataRegistro { get; set; }
    }
}
