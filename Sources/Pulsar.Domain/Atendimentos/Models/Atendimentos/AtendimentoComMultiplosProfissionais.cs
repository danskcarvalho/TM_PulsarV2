using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoComMultiplosProfissionais : Atendimento
    {
        public AtendimentoComMultiplosProfissionais()
        {
            Tipo = TipoAtendimento.MultiplosProfissionais;
        }

        public List<ObjectId> Profissionais { get; set; }
        public ObjectId AtendimentoRaiz { get; set; }
        public List<ObjectId> AtendimentoFilhos { get; set; }
    }
}
