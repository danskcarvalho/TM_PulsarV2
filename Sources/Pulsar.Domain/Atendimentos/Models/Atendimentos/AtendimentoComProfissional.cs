using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Agendamentos.Models;
using Pulsar.Domain.Global.Models;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Pastas.Models;
using Pulsar.Domain.Servicos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar.Domain.Common;
using Pulsar.Domain.Acompanhamentos.Models;
using Pulsar.Domain.Notificacoes.Models;
using Pulsar.Common.Exceptions;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoComProfissional : Atendimento
    {
        public ObjectId? ProfissionalId { get; set; }
        private ObjectId? _servicoId = null;
        public ObjectId? ServicoId
        {
            get => _servicoId;
            set
            {
                if (_servicoId != value && _servicoId != null && !IsInitializing)
                {
                    if (UltimosServicos == null)
                        UltimosServicos = new List<ObjectId>();

                    UltimosServicos.Insert(0, _servicoId.Value);
                    while (UltimosServicos.Count > 10)
                        UltimosServicos.RemoveAt(UltimosServicos.Count - 1);
                }
                _servicoId = value;
            }
        }
        public List<ObjectId> UltimosServicos { get; set; } = new List<ObjectId>();
        public List<ObjectId> ItensFilaAtendimentos { get; set; } = new List<ObjectId>();
        public ObjectId AtendimentoRaizId { get; set; }
        private StatusAtendimento _status;
        public StatusAtendimento Status
        {
            get => _status;
            set
            {
                if (_status != value && !IsInitializing)
                {
                    if (HistoricoStatus == null)
                        HistoricoStatus = new HistoricoStatus();
                    HistoricoStatus.MudancasStatus.Add(new HistoricoStatusItem()
                    {
                        StatusAnterior = _status == 0 ? null : _status,
                        StatusPosterior = value,
                        Ocorrencia = DateTime.Now
                    });
                }
                _status = value;
            }
        }
        public HistoricoStatus HistoricoStatus { get; set; } = new HistoricoStatus();
        public RealizacaoAtendimento Realizacao { get; set; } = new RealizacaoAtendimento();
        public EspecialidadeResumida Especialidade { get; set; }
        public ConselhoProfissional ConselhoProfissional { get; set; }
        public ObjectId? EquipeId { get; set; }
        public ObjectId? AgendamentoId { get; set; }
        public List<ProcedimentoReportado> ProcedimentosReportados { get; set; } = new List<ProcedimentoReportado>();
        public List<PastaArquivo> Documentos { get; set; } = new List<PastaArquivo>();
        public List<ObjectId> Acompanhamentos { get; set; } = new List<ObjectId>();
        public ObjectId? AgendamentoAoFinalizarId { get; set; }
        public ObjectId? AtendimentoInclusoAoFinalizarId { get; set; }
        
        public override async Task Abrir(ObjectId usuarioId, ObjectId filaAtendimentosId, Container container)
        {
            //atualiza atendimento raiz
            var atendimentoRaiz = await container.Atendimentos.Cast<AtendimentoRaiz>().FindOneById(AtendimentoRaizId);
            atendimentoRaiz.Status = StatusAtendimentoRaiz.Aberto;
            atendimentoRaiz.DataRegistro.Atualizado(usuarioId);
            atendimentoRaiz.DataVersion++;
            await container.Atendimentos.UpdateOne(atendimentoRaiz);

            //entrar nos acompanhamentos pertinentes
            var estabelecimento = await container.Estabelecimentos.FindOneById(this.EstabelecimentoId, x => new Estabelecimento()
            {
                Id = x.Id,
                Servicos = x.Servicos
            }, noSession: true);
            if (this.ServicoId != null)
            {
                AcompanhamentoTipo? acompanhamentoTipo = null;
                if (estabelecimento.IsPreNatalOuPuerperio(this.ServicoId.Value))
                    acompanhamentoTipo = AcompanhamentoTipo.PreNatal;
                else if (estabelecimento.IsPuericultura(this.ServicoId.Value))
                    acompanhamentoTipo = AcompanhamentoTipo.Puericultura;

                if (acompanhamentoTipo != null)
                {
                    var acompanhamento = await container.Acompanhamentos.FindOne(a => a.PacienteId == this.PacienteId && a.Status == StatusAcompanhamento.Aberto &&
                            a.Tipo == acompanhamentoTipo);
                    if (acompanhamento != null)
                        await acompanhamento.Entrar(usuarioId, this, container);
                }
            }

            //atualiza a mim mesmo
            ItensFilaAtendimentos = new List<ObjectId>() { filaAtendimentosId }; //só vai estar nesta fila de atendimento...
            Status = StatusAtendimento.Aberto;
            HistoricoStatus.PrimeiraAbertura = DateTime.Now;
            DataRegistro.Atualizado(usuarioId);
            DataVersion++;
            await container.Atendimentos.UpdateOne(this);

            //enviar notificações
            await EnviarNotificacoesAbertura(usuarioId, container, atendimentoRaiz);
        }

        public override async Task Reabrir(Usuario usuario, Estabelecimento estabelecimento, Container container)
        {
            if (this.ProfissionalId != usuario.Id)
                throw new PulsarException(PulsarErrorCode.BadRequest, "Apenas o profissional deste atendimento pode reabri-lo.");
            if (this.Status != StatusAtendimento.Finalizado)
                throw new PulsarException(PulsarErrorCode.BadRequest, "O atendimento não foi finalizado.");

            //atualiza atendimento raiz
            var atendimentoRaiz = await container.Atendimentos.Cast<AtendimentoRaiz>().FindOneById(AtendimentoRaizId);
            atendimentoRaiz.Status = StatusAtendimentoRaiz.Aberto;
            atendimentoRaiz.DataRegistro.Atualizado(usuario.Id);
            atendimentoRaiz.DataVersion++;
            await container.Atendimentos.UpdateOne(atendimentoRaiz);

            //atualiza a mim mesmo
            this.Status = StatusAtendimento.Aberto;
            this.HistoricoStatus.UltimaReabertura = DateTime.Now;
            this.DataRegistro.Atualizado(usuario.Id);
            this.DataVersion++;
            await container.Atendimentos.UpdateOne(this);

            //atualiza a fila de atendimento
            var filaAtendimentos = await container.ItensFilaAtendimentos.FindOneById(this.ItensFilaAtendimentos.First()); //só pode estar em uma única fila de atendimentos
            var item = filaAtendimentos.Items.FirstOrDefault(x => x.AtendimentoId == this.Id);
            item.Status = StatusAtendimento.Aberto;
            filaAtendimentos.Status = StatusFilaAtendimento.Aberta;
            await container.ItensFilaAtendimentos.UpdateOne(filaAtendimentos);

            //atualizar acompanhamentos
            var acompanhamentos = await container.Acompanhamentos.FindManyById(this.Acompanhamentos);
            foreach (var a in acompanhamentos)
                await a.AtualizarAtendimento(usuario.Id, this, container);
        }

        public override async Task Acompanhar(Usuario usuario, Estabelecimento estabelecimento, Container container)
        {
            if (this.ProfissionalId != usuario.Id)
                throw new PulsarException(PulsarErrorCode.BadRequest, "Apenas o profissional deste atendimento pode reabri-lo.");
            if (this.Status != StatusAtendimento.Aberto)
                throw new PulsarException(PulsarErrorCode.BadRequest, "O atendimento não está aberto.");

            //atualizar a mim mesmo
            this.Status = StatusAtendimento.AguardandoRetorno;
            this.HistoricoStatus.UltimaInterrupcao = DateTime.Now;
            this.DataRegistro.Atualizado(usuario.Id);
            this.DataVersion++;
            await container.Atendimentos.UpdateOne(this);

            //possui atividades abertas?
            var atendimentoRaiz = await container.Atendimentos.FindOneById(this.AtendimentoRaizId) as AtendimentoRaiz;
            if (atendimentoRaiz.PossuiAtividadesAbertas)
                await atendimentoRaiz.CriarRealizacoesProcedimento(usuario, estabelecimento, container);
        }

        private async Task EnviarNotificacoesAbertura(ObjectId usuarioId, Container container, AtendimentoRaiz atendimentoRaiz)
        {
            var euMesmo = await container.Usuarios.FindOneById(usuarioId, noSession: true);
            var paciente = await container.Pacientes.FindOneById(this.PacienteId, noSession: true);
            var outrosProfissionais = await container.Atendimentos.Cast<AtendimentoComProfissional>().FindMany(
                a => a is AtendimentoComProfissional && a.AtendimentoRaizId == atendimentoRaiz.Id && a.Status != StatusAtendimento.Cancelado &&
                    a.Status != StatusAtendimento.Finalizado && a.ProfissionalId != null && a.ProfissionalId != usuarioId,
                a => a.ProfissionalId.Value);
            foreach (var profId in outrosProfissionais)
            {
                await container.Notificacoes.InsertOne(new Notificacao()
                {
                    DataRegistro = DataRegistro.CriadoHoje(usuarioId),
                    EstabelecimentoId = this.EstabelecimentoId,
                    Id = ObjectId.GenerateNewId(),
                    Tipo = NotificacaoTipo.AtendimentoAberto,
                    UsuarioId = profId,
                    Mensagem = $"O profissional {euMesmo.DadosPessoais.Nome} iniciou o atendimento para o paciente {paciente.DadosBasicos.NomeSocial ?? paciente.DadosBasicos.Nome}.",
                    Parametros = new
                    {
                        Profissionald = usuarioId,
                        AtendimentoId = this.Id,
                        PacienteId = this.PacienteId
                    }.ToBsonDocument()
                });
            }
        }
    }
}
