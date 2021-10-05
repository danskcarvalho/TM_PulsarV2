using MongoDB.Bson;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Common
{
    public class DataRegistro
    {
        public DateTime? CriadoEm { get; set; }
        public ObjectId? CriadoPorUsuarioId { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public ObjectId? AtualizadoPorUsuarioId { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public ObjectId? DeletadoPorUsuarioId { get; set; }

        public static DataRegistro CriadoHoje(ObjectId usuarioId)
        {
            return new DataRegistro()
            {
                CriadoEm = DateTime.Now,
                CriadoPorUsuarioId = usuarioId,
                AtualizadoEm = DateTime.Now,
                AtualizadoPorUsuarioId = usuarioId
            };
        }

        public void Atualizado(ObjectId usuarioId)
        {
            AtualizadoEm = DateTime.Now;
            AtualizadoPorUsuarioId = usuarioId;
        }

        public void Removida(ObjectId usuarioId)
        {
            DeletadoEm = DateTime.Now;
            DeletadoPorUsuarioId = usuarioId;
        }
    }
}
