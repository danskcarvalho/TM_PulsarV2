using MongoDB.Bson;
using Pulsar.Common.Database;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Common;
using Pulsar.Domain.Estabelecimentos.Models;
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

        public AtendimentoOdontologico(ObjectId usuarioId, ObjectId atendimentoRaizId, Estabelecimento estabelecimento, ObjectId? equipeId, 
            ObjectId pacienteId, Usuario profissional, ObjectId? servicoId, ObjectId? agendamentoId) : this()
        {
            EstabelecimentoId = estabelecimento.Id;
            PacienteId = pacienteId;
            ServicoId = servicoId;
            Id = ObjectId.GenerateNewId();
            Status = StatusAtendimento.Aguardando;
            PacienteId = pacienteId;
            FichasEsus = new List<ObjectId>();
            DataRegistro = Common.DataRegistro.CriadoHoje(usuarioId);
            Motivos = new List<Motivo>();
            Problemas = new List<Problema>();
            Condutas = new List<CondutaAtendimentoOdontologico>();
            ProfissionalId = profissional?.Id;
            UltimosServicos = new List<ObjectId>();
            FilasAtendimentos = new List<ObjectId>();
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
            Especialidade = profissional?.GetLotacao(estabelecimento.Id).EspecialidadeConselho.Especialidade;
            ConselhoProfissional = profissional?.GetLotacao(estabelecimento.Id).EspecialidadeConselho.Conselho;
            EquipeId = equipeId;
            AgendamentoId = agendamentoId;
            ProcedimentosReportados = new List<ProcedimentoReportado>();
            Documentos = new List<Pastas.Models.PastaArquivo>();
            Acompanhamentos = new List<ObjectId>();
            Odontograma = new Odontograma()
            {
                Dentes = new List<OdontogramaDente>()
            };
            ProcedimentosOdontologicos = new ProcedimentosOdontologicos()
            {
                Finalizados = new List<ObjectId>(),
                Criados = new List<ObjectId>(),
                Reabertos = new List<ObjectId>(),
                Cancelados = new List<ObjectId>()
            };
            DadosOdontologicos = new DadosOdontologicos();
            if (ServicoId == estabelecimento.Servicos?.ConsultaManutencaoOdontologiaServicoId)
                DadosOdontologicos.TipoConsultaOdonto = TipoConsultaOdonto.ConsultaManutencaoOdontologia;
            else if (ServicoId == estabelecimento.Servicos?.ConsultaRetornoOdontologiaServicoId)
                DadosOdontologicos.TipoConsultaOdonto = TipoConsultaOdonto.ConsultaRetornoOdontologia;
            else if (ServicoId == estabelecimento.Servicos?.PrimeiraConsultaOdontologiaServicoId)
                DadosOdontologicos.TipoConsultaOdonto = TipoConsultaOdonto.PrimeiraConsultaOdontologicaProgramatica;

            if (agendamentoId != null)
                TipoAtendimentoEsus = Pulsar.Common.Enumerations.TipoAtendimentoEsus.ConsultaAgendada;
            else
                TipoAtendimentoEsus = Pulsar.Common.Enumerations.TipoAtendimentoEsus.ConsultaDia;
        }

        public TipoAtendimentoEsus? TipoAtendimentoEsus { get; set; }
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

        public override async Task Abrir(ObjectId usuarioId, Container container)
        {
            var ultimoAtendimento = (await container.Atendimentos.Cast<AtendimentoOdontologico>().FindMany(
                    x => x.PacienteId == this.PacienteId && x.Tipo == TipoAtendimento.Odontologico && x.Status == StatusAtendimento.Finalizado,
                    limit: 1,
                    sortBy: Sort.ByDesc<AtendimentoOdontologico>(x => x.Realizacao.Data),
                    noSession: true
                )).FirstOrDefault();
            if (ultimoAtendimento != null && ultimoAtendimento.Odontograma != null)
                this.Odontograma = ultimoAtendimento.Odontograma;


            await base.Abrir(usuarioId, container);
        }
    }
}
