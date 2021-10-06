using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Common;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Notificacoes.Models;
using Pulsar.Domain.Prontuarios.Models;
using Pulsar.Domain.Usuarios.Models;
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
        public bool PossuiAtividadesAbertas => this.Atividades.Any(a => a.Finalizacao == null);

        public async Task CriarRealizacoesProcedimento(Usuario usuario, Estabelecimento estabelecimento, Container container)
        {
            if (!PossuiAtividadesAbertas)
                return;

            var profissionais = await estabelecimento.GetProfissionaisPodemAtender(container, TipoAtendimento.RealizacaoProcedimentos);
            var paciente = await container.Pacientes.FindOneById(this.PacienteId);
            foreach (var prof in profissionais)
            {
                var filaAtendimentos = await prof.GetFilaAtendimentosDia(usuario, estabelecimento, container);
                if (filaAtendimentos.PossuiRealizacaoProcedimento)
                {
                    var item = filaAtendimentos.Items.FirstOrDefault(i => i.IsRealizacaoProcedimento && i.Status != StatusAtendimento.Cancelado);
                    if (item.Status == StatusAtendimento.Finalizado)
                    {
                        item.Status = StatusAtendimento.Aguardando;
                        item.AtualizarPode();
                        //atualiza atendimento também...
                        var atd = await container.Atendimentos.FindOneById(item.AtendimentoId.Value) as AtendimentoComProfissional;
                        atd.Status = StatusAtendimento.Aguardando;
                        await container.Atendimentos.UpdateOne(atd);
                    }

                    await filaAtendimentos.ItemAtualizado(usuario, container); 
                }
                else
                {
                    var equipes = await container.Equipes.FindMany(eq => eq.EstabelecimentoId == estabelecimento.Id &&
                        eq.DataRegistro.DeletadoEm == null, noSession: true);
                    var eqp = equipes.Where(eq => eq.Membros.Any(m => m.ProfissionalId == prof.Id)).ToList();
                    var eqpId = equipes.Count == 1 ? (ObjectId?)equipes[0].Id : null;

                    var atd = Atendimento.Criar(TipoAtendimento.RealizacaoProcedimentos, usuario.Id, this.Id, estabelecimento,
                        eqpId, this.PacienteId, prof, null, null, null) as AtendimentoComProfissional;
                    filaAtendimentos.Items.Add(new FilasAtendimentos.Models.FilaAtendimentosItem(atd));
                    await filaAtendimentos.ItemAtualizado(usuario, container);
                }

                //enviar notificação
                await container.Notificacoes.InsertOne(new Notificacao()
                {
                    DataRegistro = DataRegistro.CriadoHoje(usuario.Id),
                    EstabelecimentoId = estabelecimento.Id,
                    Id = ObjectId.GenerateNewId(),
                    Mensagem = $"O paciente {paciente.DadosBasicos.Nome} possui procedimentos pendentes.",
                    Parametros = new
                    {
                        PacienteId = paciente.Id
                    }.ToBsonDocument(),
                    Tipo = NotificacaoTipo.ProcedimentosPendentes,
                    UsuarioId = prof.Id
                });
            }
        }
    }
}
