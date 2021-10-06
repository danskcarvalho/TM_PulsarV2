using MongoDB.Bson;
using Pulsar.Common;
using Pulsar.Common.Enumerations;
using Pulsar.Common.Exceptions;
using Pulsar.Common.Services;
using Pulsar.Contracts.Atendimentos.Commands;
using Pulsar.Domain.Agendamentos.Models;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Atendimentos.Models.Atendimentos;
using Pulsar.Domain.Common;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.FilasAtendimentos.Models;
using Pulsar.Domain.Notificacoes.Models;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.Servicos.Models;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Services
{
    public class CriarAtendimentoService : IService
    { 
        public async Task Criar(CriarAtendimentoCommand cmd, Agendamento agendamento,
            Common.Container container)
        {
            var usuario = await container.Usuarios.FindOneById(cmd.UsuarioId.Value, noSession: true);
            if (usuario == null)
                throw new PulsarException(PulsarErrorCode.NotFound);

            var estabelecimento = await GetEstabelecimento(cmd, container);
            await usuario.ChecarPermissaoEstabelecimento(estabelecimento, Permissao.CriarAtendimento, container);

            //checa se agendamento pertence ao estabelecimento que se quer criar o atendimento...
            if (agendamento != null && agendamento.EstabelecimentoId != cmd.EstabelecimentoId)
                throw new PulsarException(PulsarErrorCode.BadRequest, "O agendamento não pertence ao estabelecimento informado.");
            //se agendamento for passado e o agendamento só referencia um único profissional...
            if(agendamento != null && agendamento.Configuracao?.Faixa?.Profissionais.Count == 1)
            {
                foreach (var atd in cmd.Atendimentos)
                {
                    atd.ProfissionalId = agendamento.Configuracao.Faixa.Profissionais[0];
                }
            }
            //pega o serviço do agendamento
            if(agendamento != null)
            {
                foreach (var atd in cmd.Atendimentos)
                {
                    atd.ServicoId = agendamento.ServicoId;
                }
            }

            var paciente = await TratarPaciente(cmd, container);

            //não recriaremos a alteração de prontuário se já existe
            if (await AlteracaoProntuarioExiste(cmd, paciente, container))
                return;
            await ValidarServicos(cmd, container, estabelecimento, paciente);
            var profissionais = await ValidarProfissionais(cmd, estabelecimento, container);
            //cria atendimentos
            var atendimentosCriados = await CriarAtendimentos(cmd, container, agendamento, usuario, estabelecimento, paciente, profissionais);

            //incluir nas filas de atendimentos
            var profissionaisFilasAlteradas = profissionais.Select(p => p.Value).ToList(); //profissionais que poderão ter suas filas alteradas
            profissionais = await InserirNasFilasAtendimentos(cmd, container, agendamento, usuario, estabelecimento, profissionais, atendimentosCriados, profissionaisFilasAlteradas);
            //insere atendimentos no banco
            await container.Atendimentos.InsertMany(atendimentosCriados);

            //incluindo notificações
            await CriarNotificacoes(cmd, container, usuario, estabelecimento, paciente, profissionaisFilasAlteradas);
        }

        private static async Task<Dictionary<ObjectId, Usuario>> InserirNasFilasAtendimentos(CriarAtendimentoCommand cmd, Container container, Agendamento agendamento, 
            Usuario usuario, Estabelecimento estabelecimento, Dictionary<ObjectId, Usuario> profissionais, List<Atendimento> atendimentosCriados, 
            List<Usuario> profissionaisFilasAlteradas)
        {
            if (cmd.Atendimentos.Any(a => a.Tipo == TipoAtendimento.AlteracaoProntuario))
                return profissionais;
            //algum atendimento sem informar o profissional?
            if (cmd.Atendimentos.Any(x => x.ProfissionalId == null))
            {
                if (agendamento == null || agendamento.Configuracao?.Faixa?.Profissionais == null ||
                    agendamento.Configuracao?.Faixa?.Profissionais.Count == 0) //atendimento sem agendamento?
                {
                    //pega todos os profissionais ligados ao estabelecimento...
                    if (cmd.Atendimentos.Any(a => a.ProfissionalId == null && a.Tipo != TipoAtendimento.AlteracaoProntuario))
                        profissionaisFilasAlteradas.AddRange(await container.Usuarios.FindMany(u => u.DataRegistro.DeletadoEm == null &&
                            u.LotacoesEstabelecimentos.Any(le => (le.EstabelecimentoId == estabelecimento.Id || le.RedeEstabelecimentosId == estabelecimento.RedeEstabelecimentosId) 
                            && le.Ativo), noSession: true));
                    profissionais = profissionaisFilasAlteradas.PartitionByUnique(p => p.Id);
                }
                else
                {
                    //pega os profissionais configurados no agendamento...
                    profissionaisFilasAlteradas.Clear();
                    profissionaisFilasAlteradas.AddRange(await container.Usuarios.FindManyById(agendamento.Configuracao.Faixa.Profissionais, noSession: true));
                    profissionais = profissionaisFilasAlteradas.PartitionByUnique(p => p.Id);
                }
            }

            //pega filas de atendimento existentes
            var listaProfissionaisId = profissionais.Select(x => x.Value.Id).Distinct().ToList();
            var filasAtendimentos = await container.FilasAtendimentos.FindMany(fa => listaProfissionaisId.Contains(fa.ProfissionalId) &&
                fa.EstabelecimentoId == estabelecimento.Id &&
                fa.Data == DateTime.Today);

            //mapeia profissionais para o id de uma fila de atendimento...
            var profissionaisToFila = profissionaisFilasAlteradas.PartitionByUnique(x => x.Id).ChangeValues(x =>
            {
                var fa = filasAtendimentos.FirstOrDefault(f => f.ProfissionalId == x.Id);
                if (fa != null)
                    return fa.Id;
                else //fila de atendimento não existe! será criado uma nova!
                    return ObjectId.GenerateNewId();
            });

            foreach (var atd in cmd.Atendimentos)
            {
                var atendimento = (AtendimentoComProfissional)atendimentosCriados.First(a2 => a2.Id == atd.AtendimentoId);

                if (atd.ProfissionalId != null)
                {
                    var fa = filasAtendimentos.FirstOrDefault(f => f.ProfissionalId == atd.ProfissionalId);
                    if (fa == null) //cria uma nova fila de atendimento
                    {
                        fa = new FilaAtendimentos(usuario, estabelecimento, profissionais[atd.ProfissionalId.Value], DateTime.Today);
                        fa.Items.Add(new FilaAtendimentosItem(atendimento));
                        atendimento.FilasAtendimentos.Add(fa.Id);
                        await container.FilasAtendimentos.InsertOne(fa);
                    }
                    else
                    {
                        fa.Items.Add(new FilaAtendimentosItem(atendimento));
                        fa.Status = StatusFilaAtendimento.Aberta;
                        atendimento.FilasAtendimentos.Add(fa.Id);
                        fa.DataVersion++;
                        fa.DataRegistro.AtualizadoEm = DateTime.Now;
                        fa.DataRegistro.AtualizadoPorUsuarioId = usuario.Id;
                        await container.FilasAtendimentos.UpdateOne(fa);
                    }
                }
                else
                {
                    ObjectId idCorrelacao = ObjectId.GenerateNewId();

                    //profissionais cujo atendimento será incluído na fila
                    List<Usuario> profissionaisFila = new List<Usuario>();
                    foreach (var prof in profissionaisFilasAlteradas)
                    {
                        if (!await prof.PodeAtender(estabelecimento, atd.Tipo.Value, container))
                            continue;

                        profissionaisFila.Add(prof);
                    }

                    if (profissionaisFila.Count == 0)
                        throw new PulsarException(PulsarErrorCode.BadRequest, "Não há filas de atendimentos disponíveis para inserir o atendimento.");

                    foreach (var prof in profissionaisFila)
                    {
                        var fa = filasAtendimentos.FirstOrDefault(f => f.ProfissionalId == prof.Id);
                        if (fa == null) //cria uma nova fila de atendimento
                        {
                            fa = new FilaAtendimentos(usuario, estabelecimento, prof, DateTime.Today);
                            fa.Id = profissionaisToFila[fa.ProfissionalId];
                            fa.Items.Add(new FilaAtendimentosItem(atendimento,
                                idCorrelacao,
                                //filas correlacionadas
                                profissionaisFila.Where(u => u.Id != prof.Id).Select(u => profissionaisToFila[u.Id])));
                            atendimento.FilasAtendimentos.Add(fa.Id);
                            await container.FilasAtendimentos.InsertOne(fa);
                        }
                        else
                        {
                            fa.Items.Add(new FilaAtendimentosItem(atendimento,
                                idCorrelacao,
                                //filas correlacionadas
                                profissionaisFila.Where(u => u.Id != prof.Id).Select(u => profissionaisToFila[u.Id])));
                            atendimento.FilasAtendimentos.Add(fa.Id);
                            fa.Status = StatusFilaAtendimento.Aberta;
                            fa.DataVersion++;
                            fa.DataRegistro.AtualizadoEm = DateTime.Now;
                            fa.DataRegistro.AtualizadoPorUsuarioId = usuario.Id;
                            await container.FilasAtendimentos.UpdateOne(fa);
                        }
                    }
                }
            }

            return profissionais;
        }

        private static async Task CriarNotificacoes(CriarAtendimentoCommand cmd, Container container, Usuario usuario, 
            Estabelecimento estabelecimento, Paciente paciente, List<Usuario> todosProfissionais)
        {
            foreach (var atd in cmd.Atendimentos)
            {
                if (atd.Tipo == TipoAtendimento.AlteracaoProntuario)
                    continue;

                if (atd.ProfissionalId != null)
                {
                    await container.Notificacoes.InsertOne(new Notificacao()
                    {
                        DataRegistro = DataRegistro.CriadoHoje(usuario.Id),
                        EstabelecimentoId = estabelecimento.Id,
                        Id = ObjectId.GenerateNewId(),
                        Mensagem = $"O paciente {paciente.DadosBasicos.Nome} foi incluído em sua fila de atendimentos.",
                        Parametros = new
                        {
                            AtendimentoId = atd.AtendimentoId,
                            PacienteId = paciente.Id
                        }.ToBsonDocument(),
                        Tipo = NotificacaoTipo.NovoAtendimento,
                        UsuarioId = atd.ProfissionalId.Value
                    });
                }
                else
                {
                    foreach (var prof in todosProfissionais)
                    {
                        if (!await prof.PodeAtender(estabelecimento, atd.Tipo.Value, container))
                            continue;

                        await container.Notificacoes.InsertOne(new Notificacao()
                        {
                            DataRegistro = DataRegistro.CriadoHoje(usuario.Id),
                            EstabelecimentoId = estabelecimento.Id,
                            Id = ObjectId.GenerateNewId(),
                            Mensagem = $"O paciente {paciente.DadosBasicos.Nome} foi incluído em sua fila de atendimentos.",
                            Parametros = new
                            {
                                AtendimentoId = atd.AtendimentoId,
                                PacienteId = paciente.Id
                            }.ToBsonDocument(),
                            Tipo = NotificacaoTipo.NovoAtendimento,
                            UsuarioId = prof.Id
                        });
                    }
                }
            }
        }

        private static async Task<List<Atendimento>> CriarAtendimentos(CriarAtendimentoCommand cmd, Container container, Agendamento agendamento,
            Usuario usuario, Estabelecimento estabelecimento, Paciente paciente, Dictionary<ObjectId, Usuario> profissionais)
        {
            //cria atendimento raiz
            List<Atendimento> atendimentosCriados = new List<Atendimento>();
            var atendimentoRaiz = new AtendimentoRaiz(cmd.UsuarioId.Value, cmd.EstabelecimentoId.Value, cmd.Categoria.Value, paciente.Id);
            atendimentosCriados.Add(atendimentoRaiz);
            //se for alteração do prontuário então o atendimento estará sincronizado com o prontuário instantaneamente
            if (cmd.Atendimentos.Any(a => a.Tipo == TipoAtendimento.AlteracaoProntuario))
                atendimentoRaiz.AtualizacaoPronturarioImediata = true;

            //pega equipes do estabelecimento
            var equipes = await container.Equipes.FindMany(eq => eq.EstabelecimentoId == estabelecimento.Id &&
                eq.DataRegistro.DeletadoEm == null, noSession: true);

            foreach (var atd in cmd.Atendimentos)
            {
                var eqp = equipes.Where(eq => eq.Membros.Any(m => m.ProfissionalId == atd.ProfissionalId)).ToList();
                ObjectId? equipeId = null;
                if (atd.ProfissionalId != null && eqp.Count == 1)
                    equipeId = eqp.First().Id;

                var atendimento = Atendimento.Criar(atd.Tipo.Value,
                    usuario.Id,
                    atendimentoRaiz.Id,
                    estabelecimento,
                    equipeId,
                    paciente.Id,
                    atd.ProfissionalId.HasValue ? profissionais[atd.ProfissionalId.Value] : null,
                    atd.ServicoId,
                    agendamento?.Id,
                    atd.Justificativa);
                atd.AtendimentoId = atendimento.Id;
                atendimentosCriados.Add(atendimento);
            }

            return atendimentosCriados;
        }

        private static async Task<Dictionary<ObjectId, Usuario>> ValidarProfissionais(CriarAtendimentoCommand cmd, Estabelecimento estabelecimento, Container container)
        {
            var profissionais = await container.Usuarios.FindManyById(cmd.Atendimentos.Where(a => a.ProfissionalId != null).Select(a => a.ProfissionalId.Value), noSession: true);
            var profissionalPorId = profissionais.PartitionByUnique(s => s.Id);

            foreach (var atd in cmd.Atendimentos)
            {
                if (atd.Tipo == TipoAtendimento.AlteracaoProntuario)
                    atd.ProfissionalId = cmd.UsuarioId;
                if (atd.ProfissionalId != null)
                {
                    if (!profissionalPorId.ContainsKey(atd.ProfissionalId.Value))
                        throw new PulsarException(PulsarErrorCode.NotFound);

                    var profissional = profissionalPorId[atd.ServicoId.Value];
                    if (profissional.DataRegistro.DeletadoEm != null)
                        throw new PulsarException(PulsarErrorCode.NotFound);
                    if (!await profissional.PossuiPermissaoEstabelecimento(estabelecimento, atd.Tipo.Value.GetPermissao(), container))
                        throw new PulsarException(PulsarErrorCode.BadRequest, $"O profissional {profissional.DadosPessoais.Nome} não possui as permissões necessárias para realizar este tipo de atendimento.");
                }
            }

            return profissionalPorId;
        }

        private static async Task<Dictionary<ObjectId, Servico>> ValidarServicos(CriarAtendimentoCommand cmd, Container container, Estabelecimento estabelecimento, Paciente paciente)
        {
            var servicos = await container.Servicos.FindManyById(cmd.Atendimentos.Where(a => a.ServicoId != null).Select(a => a.ServicoId.Value), noSession: false);
            var servicoPorId = servicos.PartitionByUnique(s => s.Id);

            foreach (var atd in cmd.Atendimentos)
            {
                if (atd.ServicoId != null)
                {
                    if (!servicoPorId.ContainsKey(atd.ServicoId.Value))
                        throw new PulsarException(PulsarErrorCode.NotFound);

                    var servico = servicoPorId[atd.ServicoId.Value];

                    if (!servico.TiposAtendimentos.Any(ta => ta.TipoAtendimento == atd.Tipo.Value))
                        throw new PulsarException(PulsarErrorCode.BadRequest, "O serviço informado não é compatível com o tipo de atendimento informado.");
                    if (servico.DataRegistro.DeletadoEm != null)
                        throw new PulsarException(PulsarErrorCode.NotFound);
                    if (servico.RedeEstabelecimentosId != estabelecimento.RedeEstabelecimentosId)
                        throw new PulsarException(PulsarErrorCode.BadRequest, $"O serviço {servico.Nome} não é compatível com o estabelecimento {estabelecimento.DadosBasicos.Nome}.");

                    var idade = paciente.GetIdade().TotalDias;
                    if (servico.Restricoes != null)
                    {
                        if (!servico.Restricoes.Sexo.Permite(paciente.DadosBasicos.Sexo))
                            throw new PulsarException(PulsarErrorCode.BadRequest, $"O sexo do paciente não é compatível com o serviço {servico.Nome}.");

                        if (servico.Restricoes.IdadeMinimaEmDias != null && idade < servico.Restricoes.IdadeMinimaEmDias)
                            throw new PulsarException(PulsarErrorCode.BadRequest, $"A idade do paciente não é compatível com o serviço {servico.Nome}.");

                        if (servico.Restricoes.IdadeMaximaEmDias != null && idade > servico.Restricoes.IdadeMinimaEmDias)
                            throw new PulsarException(PulsarErrorCode.BadRequest, $"A idade do paciente não é compatível com o serviço {servico.Nome}.");
                    }
                }
            }

            return servicoPorId;
        }

        private static async Task<Estabelecimento> GetEstabelecimento(CriarAtendimentoCommand cmd, Container container)
        {
            var estabelecimento = await container.Estabelecimentos.FindOneById(cmd.EstabelecimentoId.Value, e => new Estabelecimento()
            {
                Id = e.Id,
                RedeEstabelecimentosId = e.RedeEstabelecimentosId,
                DadosBasicos = new Estabelecimentos.Models.DadosBasicos
                {
                    Nome = e.DadosBasicos.Nome
                },
                Servicos = e.Servicos
            }, noSession: true);
            if (estabelecimento == null)
                throw new PulsarException(PulsarErrorCode.NotFound);
            return estabelecimento;
        }

        private async Task<bool> AlteracaoProntuarioExiste(CriarAtendimentoCommand cmd, Paciente paciente, Common.Container container)
        {
            if (cmd.Atendimentos.Any(a => a.Tipo == TipoAtendimento.AlteracaoProntuario))
            {
                //verifica se já existe
                var ap = await container.Atendimentos.Cast<AlteracaoProntuario>().FindOne(
                        x => x.Tipo == TipoAtendimento.AlteracaoProntuario && x.Data == DateTime.Today && x.ProfissionalId == cmd.UsuarioId.Value && x.EstabelecimentoId == cmd.EstabelecimentoId &&
                             x.PacienteId == paciente.Id,
                        x => new AlteracaoProntuario() { Id = x.Id });
                if (ap != null)
                {
                    cmd.Atendimentos.First().AtendimentoId = ap.Id;
                    var justificativa = cmd.Atendimentos.First().Justificativa;
                    //atualiza a justificativa
                    await container.Atendimentos.Cast<AlteracaoProntuario>().UpdateOne(x => x.Id == ap.Id,
                        u => u.Set(ap2 => ap2.Justificativa, justificativa));
                    //não recriamos a alteração de prontuário...
                    return true;
                }
            }
            return false;
        }

        private static async Task<Paciente> TratarPaciente(CriarAtendimentoCommand cmd, Container container)
        {
            Paciente paciente = null;
            if (cmd.PacienteId != null)
            {
                paciente = await container.Pacientes.FindOneById(cmd.PacienteId.Value, p => new Paciente()
                {
                    Id = p.Id,
                    DadosBasicos = p.DadosBasicos
                });
                if (paciente == null)
                    throw new PulsarException(PulsarErrorCode.BadRequest, "Paciente não encontrado.");
            }
            else
            {
                //paciente anônimo
                paciente = Paciente.CriarPacienteAnonimo(cmd.UsuarioId.Value, cmd.PacienteAnonimo.Nome, cmd.PacienteAnonimo.Sexo.Value,
                    cmd.PacienteAnonimo.DataNascimento.Value);
                await container.Pacientes.InsertOne(paciente);
            }

            return paciente;
        }
    }
}
