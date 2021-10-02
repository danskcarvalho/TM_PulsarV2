using Pulsar.Common.Database;
using Pulsar.Domain.Acompanhamentos.Models;
using Pulsar.Domain.Agendamentos.Models;
using Pulsar.Domain.Agendas.Models;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Exportacoes.Models;
using Pulsar.Domain.Familias.Models;
using Pulsar.Domain.FichasEsus.Models;
using Pulsar.Domain.FilasAtendimentos.Models;
using Pulsar.Domain.Global.Models;
using Pulsar.Domain.Importacoes.Models;
using Pulsar.Domain.Notificacoes.Models;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.Pastas.Models;
using Pulsar.Domain.Perfis.Models;
using Pulsar.Domain.ProcedimentosOdontologicos.Models;
using Pulsar.Domain.Prontuarios.Models;
using Pulsar.Domain.RedesEstabelecimentos.Models;
using Pulsar.Domain.Servicos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Common
{
    public class ContainerFactory
    {
        public IAsyncRepositoryFactory<Acompanhamento> Acompanhamentos { get; }
        public IAsyncRepositoryFactory<Agendamento> Agendamentos { get; }
        public IAsyncRepositoryFactory<Agenda> Agendas { get; }
        public IAsyncRepositoryFactory<Escala> Escalas { get; }
        public IAsyncRepositoryFactory<Atendimento> Atendimentos { get; }
        public IAsyncRepositoryFactory<Equipe> Equipes { get; }
        public IAsyncRepositoryFactory<Estabelecimento> Estabelecimentos { get; }
        public IAsyncRepositoryFactory<Exportacao> Exportacoes { get; }
        public IAsyncRepositoryFactory<Familia> Familias { get; }
        public IAsyncRepositoryFactory<FichaEsus> FichasEsus { get; }
        public IAsyncRepositoryFactory<FilaAtendimentos> FilasAtendimentos { get; }
        public IAsyncRepositoryFactory<ChaveCondicaoSaude> ChavesCondicaoSaude { get; }
        public IAsyncRepositoryFactory<Dente> Dentes { get; }
        public IAsyncRepositoryFactory<Diagnostico> Diagnosticos { get; }
        public IAsyncRepositoryFactory<Especialidade> Especialidades { get; }
        public IAsyncRepositoryFactory<Etnia> Etnias { get; }
        public IAsyncRepositoryFactory<Inep> Ineps { get; }
        public IAsyncRepositoryFactory<Material> Materiais { get; }
        public IAsyncRepositoryFactory<PerguntaPuericultura> PerguntasPuericultura { get; }
        public IAsyncRepositoryFactory<PrincipioAtivo> PrincipiosAtivos { get; }
        public IAsyncRepositoryFactory<Procedimento> Procedimentos { get; }
        public IAsyncRepositoryFactory<Regiao> Regioes { get; }
        public IAsyncRepositoryFactory<Importacao> Importacoes { get; }
        public IAsyncRepositoryFactory<Notificacao> Notificacoes { get; }
        public IAsyncRepositoryFactory<Paciente> Pacientes { get; }
        public IAsyncRepositoryFactory<Pasta> Pastas { get; }
        public IAsyncRepositoryFactory<Perfil> Perfis { get; }
        public IAsyncRepositoryFactory<ProcedimentoOdontologico> ProcedimentosOdontologicos { get; }
        public IAsyncRepositoryFactory<FragmentoProntuario> Prontuarios { get; }
        public IAsyncRepositoryFactory<RedeEstabelecimentos> RedesEstabelecimentos { get; }
        public IAsyncRepositoryFactory<Servico> Servicos { get; }
        public IAsyncRepositoryFactory<Usuario> Usuarios { get; }

        public ContainerFactory(IAsyncRepositoryFactory<Acompanhamento> acompanhamentos,
                                IAsyncRepositoryFactory<Agendamento> agendamentos,
                                IAsyncRepositoryFactory<Agenda> agendas,
                                IAsyncRepositoryFactory<Escala> escalas,
                                IAsyncRepositoryFactory<Atendimento> atendimentos,
                                IAsyncRepositoryFactory<Equipe> equipes,
                                IAsyncRepositoryFactory<Estabelecimento> estabelecimentos,
                                IAsyncRepositoryFactory<Exportacao> exportacoes,
                                IAsyncRepositoryFactory<Familia> familias,
                                IAsyncRepositoryFactory<FichaEsus> fichasEsus,
                                IAsyncRepositoryFactory<FilaAtendimentos> filasAtendimentos,
                                IAsyncRepositoryFactory<ChaveCondicaoSaude> chavesCondicaoSaude,
                                IAsyncRepositoryFactory<Dente> dentes,
                                IAsyncRepositoryFactory<Diagnostico> diagnosticos,
                                IAsyncRepositoryFactory<Especialidade> especialidades,
                                IAsyncRepositoryFactory<Etnia> etnias,
                                IAsyncRepositoryFactory<Inep> ineps,
                                IAsyncRepositoryFactory<Material> materiais,
                                IAsyncRepositoryFactory<PerguntaPuericultura> perguntasPuericultura,
                                IAsyncRepositoryFactory<PrincipioAtivo> principiosAtivos,
                                IAsyncRepositoryFactory<Procedimento> procedimentos,
                                IAsyncRepositoryFactory<Regiao> regioes,
                                IAsyncRepositoryFactory<Importacao> importacoes,
                                IAsyncRepositoryFactory<Notificacao> notificacoes,
                                IAsyncRepositoryFactory<Paciente> pacientes,
                                IAsyncRepositoryFactory<Pasta> pastas,
                                IAsyncRepositoryFactory<Perfil> perfis,
                                IAsyncRepositoryFactory<ProcedimentoOdontologico> procedimentosOdontologicos,
                                IAsyncRepositoryFactory<FragmentoProntuario> prontuarios,
                                IAsyncRepositoryFactory<RedeEstabelecimentos> redesEstabelecimentos,
                                IAsyncRepositoryFactory<Servico> servicos,
                                IAsyncRepositoryFactory<Usuario> usuarios)
        {
            Acompanhamentos = acompanhamentos;
            Agendamentos = agendamentos;
            Agendas = agendas;
            Escalas = escalas;
            Atendimentos = atendimentos;
            Equipes = equipes;
            Estabelecimentos = estabelecimentos;
            Exportacoes = exportacoes;
            Familias = familias;
            FichasEsus = fichasEsus;
            FilasAtendimentos = filasAtendimentos;
            ChavesCondicaoSaude = chavesCondicaoSaude;
            Dentes = dentes;
            Diagnosticos = diagnosticos;
            Especialidades = especialidades;
            Etnias = etnias;
            Ineps = ineps;
            Materiais = materiais;
            PerguntasPuericultura = perguntasPuericultura;
            PrincipiosAtivos = principiosAtivos;
            Procedimentos = procedimentos;
            Regioes = regioes;
            Importacoes = importacoes;
            Notificacoes = notificacoes;
            Pacientes = pacientes;
            Pastas = pastas;
            Perfis = perfis;
            ProcedimentosOdontologicos = procedimentosOdontologicos;
            Prontuarios = prontuarios;
            RedesEstabelecimentos = redesEstabelecimentos;
            Servicos = servicos;
            Usuarios = usuarios;
        }

        public Container Create(IDbContext ctx)
        {
            return new Container(
                Acompanhamentos.Get(ctx),
                Agendamentos.Get(ctx),
                Agendas.Get(ctx),
                Escalas.Get(ctx),
                Atendimentos.Get(ctx),
                Equipes.Get(ctx),
                Estabelecimentos.Get(ctx),
                Exportacoes.Get(ctx),
                Familias.Get(ctx),
                FichasEsus.Get(ctx),
                FilasAtendimentos.Get(ctx),
                ChavesCondicaoSaude.Get(ctx),
                Dentes.Get(ctx),
                Diagnosticos.Get(ctx),
                Especialidades.Get(ctx),
                Etnias.Get(ctx),
                Ineps.Get(ctx),
                Materiais.Get(ctx),
                PerguntasPuericultura.Get(ctx),
                PrincipiosAtivos.Get(ctx),
                Procedimentos.Get(ctx),
                Regioes.Get(ctx),
                Importacoes.Get(ctx),
                Notificacoes.Get(ctx),
                Pacientes.Get(ctx),
                Pastas.Get(ctx),
                Perfis.Get(ctx),
                ProcedimentosOdontologicos.Get(ctx),
                Prontuarios.Get(ctx),
                RedesEstabelecimentos.Get(ctx),
                Servicos.Get(ctx),
                Usuarios.Get(ctx));
        }
    }
}
