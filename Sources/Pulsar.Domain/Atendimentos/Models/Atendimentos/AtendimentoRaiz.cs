using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Common;
using Pulsar.Domain.Prontuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoRaiz : Atendimento
    {
        public AtendimentoRaiz()
        {
            Tipo = TipoAtendimento.Raiz;
        }

        public AtendimentoRaiz(ObjectId usuarioId, 
            ObjectId estabelecimentoId, 
            CategoriaAtendimento categoria, 
            ObjectId pacienteId) : base()
        {
            Id = ObjectId.GenerateNewId();
            if (categoria == CategoriaAtendimento.Individual || categoria == CategoriaAtendimento.Retroativo)
                Local = LocalAtendimento.Ubs;

            Endereco = new Endereco();
            Categoria = categoria;
            Status = StatusAtendimentoRaiz.Aberto;
            EstabelecimentoId = estabelecimentoId;
            PacienteId = pacienteId;
            DataRegistro = DataRegistro.CriadoHoje(usuarioId);
        }

        public LocalAtendimento? Local { get; set; }
        public Endereco Endereco { get; set; }
        public ModalidadeAD? ModalidadeAD { get; set; }
        public CategoriaAtendimento Categoria { get; set; }
        public RegistroEvasao RegistroEvasao { get; set; }
        public RiscoAtendimento? Risco { get; set; }
        public StatusAtendimentoRaiz Status { get; set; }
        public List<Atividade> Atividades { get; set; } = new List<Atividade>();
        public List<ArtefatoAtendimento> Artefatos { get; set; } = new List<ArtefatoAtendimento>();
        public List<FragmentoProntuario> AlteracoesProntuario { get; set; } = new List<FragmentoProntuario>();
        public bool AtualizacaoPronturarioImediata { get; set; }
    }
}
