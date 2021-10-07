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
    public class Container
    {
        private IDbContext _Context = null;
        public IAsyncRepository<Acompanhamento> Acompanhamentos { get; }
        public IAsyncRepository<Agendamento> Agendamentos { get; }
        public IAsyncRepository<Agenda> Agendas { get; }
        public IAsyncRepository<Escala> Escalas { get; }
        public IAsyncRepository<Atendimento> Atendimentos { get; }
        public IAsyncRepository<Equipe> Equipes { get; }
        public IAsyncRepository<Estabelecimento> Estabelecimentos { get; }
        public IAsyncRepository<Exportacao> Exportacoes { get; }
        public IAsyncRepository<Familia> Familias { get; }
        public IAsyncRepository<FichaEsus> FichasEsus { get; }
        public IAsyncRepository<ItemFilaAtendimentos> ItensFilaAtendimentos { get; }
        public IAsyncRepository<ChaveCondicaoSaude> ChavesCondicaoSaude { get; }
        public IAsyncRepository<Dente> Dentes { get; }
        public IAsyncRepository<Diagnostico> Diagnosticos { get; }
        public IAsyncRepository<Especialidade> Especialidades { get; }
        public IAsyncRepository<Etnia> Etnias { get; }
        public IAsyncRepository<Inep> Ineps { get; }
        public IAsyncRepository<Material> Materiais { get; }
        public IAsyncRepository<PerguntaPuericultura> PerguntasPuericultura { get; }
        public IAsyncRepository<PrincipioAtivo> PrincipiosAtivos { get; }
        public IAsyncRepository<Procedimento> Procedimentos { get; }
        public IAsyncRepository<Regiao> Regioes { get; }
        public IAsyncRepository<Importacao> Importacoes { get; }
        public IAsyncRepository<Notificacao> Notificacoes { get; }
        public IAsyncRepository<Paciente> Pacientes { get; }
        public IAsyncRepository<Pasta> Pastas { get; }
        public IAsyncRepository<Perfil> Perfis { get; }
        public IAsyncRepository<ProcedimentoOdontologico> ProcedimentosOdontologicos { get; }
        public IAsyncRepository<FragmentoProntuario> Prontuarios { get; }
        public IAsyncRepository<RedeEstabelecimentos> RedesEstabelecimentos { get; }
        public IAsyncRepository<Servico> Servicos { get; }
        public IAsyncRepository<Usuario> Usuarios { get; }

        public Container(IDbContext ctx,
                         IAsyncRepository<Acompanhamento> acompanhamentos,
                         IAsyncRepository<Agendamento> agendamentos,
                         IAsyncRepository<Agenda> agendas,
                         IAsyncRepository<Escala> escalas,
                         IAsyncRepository<Atendimento> atendimentos,
                         IAsyncRepository<Equipe> equipes,
                         IAsyncRepository<Estabelecimento> estabelecimentos,
                         IAsyncRepository<Exportacao> exportacoes,
                         IAsyncRepository<Familia> familias,
                         IAsyncRepository<FichaEsus> fichasEsus,
                         IAsyncRepository<ItemFilaAtendimentos> filasAtendimentos,
                         IAsyncRepository<ChaveCondicaoSaude> chavesCondicaoSaude,
                         IAsyncRepository<Dente> dentes,
                         IAsyncRepository<Diagnostico> diagnosticos,
                         IAsyncRepository<Especialidade> especialidades,
                         IAsyncRepository<Etnia> etnias,
                         IAsyncRepository<Inep> ineps,
                         IAsyncRepository<Material> materiais,
                         IAsyncRepository<PerguntaPuericultura> perguntasPuericultura,
                         IAsyncRepository<PrincipioAtivo> principiosAtivos,
                         IAsyncRepository<Procedimento> procedimentos,
                         IAsyncRepository<Regiao> regioes,
                         IAsyncRepository<Importacao> importacoes,
                         IAsyncRepository<Notificacao> notificacoes,
                         IAsyncRepository<Paciente> pacientes,
                         IAsyncRepository<Pasta> pastas,
                         IAsyncRepository<Perfil> perfis,
                         IAsyncRepository<ProcedimentoOdontologico> procedimentosOdontologicos,
                         IAsyncRepository<FragmentoProntuario> prontuarios,
                         IAsyncRepository<RedeEstabelecimentos> redesEstabelecimentos,
                         IAsyncRepository<Servico> servicos,
                         IAsyncRepository<Usuario> usuarios)
        {
            _Context = ctx;
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
            ItensFilaAtendimentos = filasAtendimentos;
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

        public Task Flush()
        {
            return _Context.Flush();
        }
    }
}
