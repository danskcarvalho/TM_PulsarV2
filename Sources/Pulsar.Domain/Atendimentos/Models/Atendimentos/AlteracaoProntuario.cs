using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Common.Exceptions;
using Pulsar.Domain.Common;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AlteracaoProntuario : AtendimentoComProfissional
    {
        public AlteracaoProntuario()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtendimento.AlteracaoProntuario;
        }

        public AlteracaoProntuario(ObjectId usuarioId, ObjectId atendimentoRaizId, Estabelecimento estabelecimento, ObjectId pacienteId, Usuario profissional,
            string justificativa) : this()
        {
            EstabelecimentoId = estabelecimento.Id;
            PacienteId = pacienteId;
            Id = ObjectId.GenerateNewId();
            Status = StatusAtendimento.Aguardando;
            PacienteId = pacienteId;
            DataRegistro = Common.DataRegistro.CriadoHoje(usuarioId);
            ProfissionalId = profissional.Id;
            AtendimentoRaizId = atendimentoRaizId;
            Especialidade = profissional.GetLotacao(estabelecimento)?.EspecialidadeConselho.Especialidade;
            ConselhoProfissional = profissional.GetLotacao(estabelecimento)?.EspecialidadeConselho.Conselho;
            Data = DateTime.Today;
            Justificativa = justificativa;
        }

        public DateTime Data { get; set; }
        public string Justificativa { get; set; }

        public override Task Acompanhar(Usuario usuario, Estabelecimento estabelecimento, Container container)
        {
            throw new PulsarException(PulsarErrorCode.BadRequest, "Não é possível realizar esta operação.");
        }

        public override Task Reabrir(Usuario usuario, Estabelecimento estabelecimento, Container container)
        {
            throw new PulsarException(PulsarErrorCode.BadRequest, "Não é possível realizar esta operação.");
        }
    }
}
