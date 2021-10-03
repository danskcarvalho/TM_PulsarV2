using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.ProcedimentosOdontologicos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoOdontologico : AtendimentoComProfissional
    {
        public AtendimentoOdontologico()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtendimento.Odontologico;
        }

        public AtendimentoOdontologico(ObjectId usuarioId, ObjectId atendimentoRaizId, ObjectId estabelecimentoId, ObjectId? equipeId, ObjectId pacienteId, Usuario profissional, ObjectId? servicoId, ObjectId? agendamentoId) : base()
        {
            EstabelecimentoId = estabelecimentoId;
            PacienteId = pacienteId;
            ServicoId = servicoId;
            Id = ObjectId.GenerateNewId();
            Status = StatusAtendimento.Aguardando;
            EstabelecimentoId = estabelecimentoId;
            PacienteId = pacienteId;
            FichasEsus = new List<ObjectId>();
            DataRegistro = Common.DataRegistro.CriadoHoje(usuarioId);
            Motivos = new List<Motivo>();
            Problemas = new List<Problema>();
            Condutas = new List<CondutaAtendimentoOdontologico>();
            ProfissionalId = profissional.Id;
            UltimosServicos = new List<ObjectId>();
            AtendimentoRaizId = atendimentoRaizId;
            HistoricoStatus = new HistoricoStatus()
            {
                MudancasStatus = new List<HistoricoStatusItem>()
                {
                    new HistoricoStatusItem()
                    {
                        StatusAnterior = null,
                        StatusPosterior = StatusAtendimento.Aguardando,
                        Ocorrencia = DateTime.Now
                    }
                }
            };
            Realizacao = new RealizacaoAtendimento();
            Especialidade = profissional.GetLotacao(estabelecimentoId).EspecialidadeConselho.Especialidade;
            ConselhoProfissional = profissional.GetLotacao(estabelecimentoId).EspecialidadeConselho.Conselho;
            EquipeId = equipeId;
            AgendamentoId = agendamentoId;
            ProcedimentosReportados = new List<Global.Models.ProcedimentoResumido>();
            Documentos = new List<Pastas.Models.PastaArquivo>();
            Acompanhamentos = new List<ObjectId>();
            Odontograma = new Odontograma()
            {
                Dentes = new List<OdontogramaDente>()
            };
            ProcedimentosOdontologicos = new ProcedimentosOdontologicos()
            {
                Concluidos = new List<ObjectId>(),
                Criados = new List<ObjectId>(),
                Desfeitos = new List<ObjectId>()
            };
        }

        public Antropometria Antropometria { get; set; }
        public Avaliacao Avaliacao { get; set; }
        public DadosOdontologicos DadosOdontologicos { get; set; }
        public ExameFisico ExameFisico { get; set; }
        public MedicaoGlicemia MedicaoGlicemia { get; set; }
        public List<Motivo> Motivos { get; set; }
        public Objetivo Objetivo { get; set; }
        public Odontograma Odontograma { get; set; }
        public Plano Plano { get; set; }
        public List<Problema> Problemas { get; set; }
        public SinaisVitais SinaisVitais { get; set; }
        public Subjetivo Subjetivo { get; set; }
        public ProcedimentosOdontologicos ProcedimentosOdontologicos { get; set; }
        public List<CondutaAtendimentoOdontologico> Condutas { get; set; }
    }
}
