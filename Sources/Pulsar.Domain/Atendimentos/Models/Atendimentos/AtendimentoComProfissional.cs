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

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoComProfissional : Atendimento
    {
        public ObjectId? ProfissionalId { get; set; }
        public ObjectId? ServicoId { get; set; }
        public List<ObjectId> UltimosServicos { get; set; }
        public List<ObjectId> FilasAtendimentos { get; set; }
        public ObjectId AtendimentoRaizId { get; set; }
        public StatusAtendimento Status { get; set; }
        public HistoricoStatus HistoricoStatus { get; set; }
        public RealizacaoAtendimento Realizacao { get; set; }
        public EspecialidadeResumida Especialidade { get; set; }
        public ConselhoProfissional ConselhoProfissional { get; set; }
        public ObjectId? EquipeId { get; set; }
        public ObjectId? AgendamentoId { get; set; }
        public List<ProcedimentoReportado> ProcedimentosReportados { get; set; }
        public List<PastaArquivo> Documentos { get; set; }
        public List<ObjectId> Acompanhamentos { get; set; }
        public ObjectId? AgendamentoAoFinalizarId { get; set; }
        public ObjectId? AtendimentoInclusoAoFinalizarId { get; set; }

        public override async Task Abrir(ObjectId usuarioId, Container container)
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
            Status = StatusAtendimento.Aberto;
            DataRegistro.Atualizado(usuarioId);
            DataVersion++;
            await container.Atendimentos.UpdateOne(this);

            //TODO: notifica outros profissionais
        }
    }
}
