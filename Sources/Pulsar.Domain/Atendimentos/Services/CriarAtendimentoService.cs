using MongoDB.Bson;
using Pulsar.Common;
using Pulsar.Common.Enumerations;
using Pulsar.Common.Exceptions;
using Pulsar.Common.Services;
using Pulsar.Contracts.Atendimentos.Commands;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Atendimentos.Models.Atendimentos;
using Pulsar.Domain.Common;
using Pulsar.Domain.Estabelecimentos.Models;
using Pulsar.Domain.Pacientes.Models;
using Pulsar.Domain.Servicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Services
{
    public class CriarAtendimentoService : IService
    { 
        public async Task Criar(CriarAtendimentoCommand cmd, Common.Container container)
        {
            var usuario = await container.Usuarios.FindOneById(cmd.UsuarioId.Value);
            if (usuario == null)
                throw new PulsarException(PulsarErrorCode.NotFound);
            await usuario.ChecarPermissaoEstabelecimento(cmd.EstabelecimentoId, Permissao.CriarAtendimento, container);
            Estabelecimento estabelecimento = await GetEstabelecimento(cmd, container);
            var paciente = await TratarPaciente(cmd, container);

            //não recriaremos a alteração de prontuário se já existe
            if (await AlteracaoProntuarioExiste(cmd, container))
                return;

            var servicos = await container.Servicos.FindManyById(cmd.Atendimentos.Where(a => a.ServicoId != null).Select(a => a.ServicoId.Value));
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
                        if (!servico.Restricoes.Sexo.Permite(paciente.DadosAtuais.DadosBasicos.Sexo))
                            throw new PulsarException(PulsarErrorCode.BadRequest, $"O sexo do paciente não é compatível com o serviço {servico.Nome}.");

                        if (servico.Restricoes.IdadeMinimaEmDias != null && idade < servico.Restricoes.IdadeMinimaEmDias)
                            throw new PulsarException(PulsarErrorCode.BadRequest, $"A idade do paciente não é compatível com o serviço {servico.Nome}.");

                        if (servico.Restricoes.IdadeMaximaEmDias != null && idade > servico.Restricoes.IdadeMinimaEmDias)
                            throw new PulsarException(PulsarErrorCode.BadRequest, $"A idade do paciente não é compatível com o serviço {servico.Nome}.");
                    }
                }
            }

            var profissionais = await container.Usuarios.FindManyById(cmd.Atendimentos.Where(a => a.ProfissionalId != null).Select(a => a.ProfissionalId.Value));
            var profissionalPorId = profissionais.PartitionByUnique(s => s.Id);

            foreach (var atd in cmd.Atendimentos)
            {
                if (atd.ProfissionalId != null)
                {
                    if (!profissionalPorId.ContainsKey(atd.ProfissionalId.Value))
                        throw new PulsarException(PulsarErrorCode.NotFound);

                    var profissional = profissionalPorId[atd.ServicoId.Value];
                    if (profissional.DataRegistro.DeletadoEm != null)
                        throw new PulsarException(PulsarErrorCode.NotFound);
                    if (!await profissional.PossuiPermissaoEstabelecimento(cmd.EstabelecimentoId, atd.Tipo.Value.GetPermissao(), container))
                        throw new PulsarException(PulsarErrorCode.BadRequest, $"O profissional {profissional.DadosPessoais.Nome} não possui as permissões necessárias para realizar este tipo de atendimento.");
                }
            }

            List<Atendimento> atendimentosCriados = new List<Atendimento>();
            var atendimentoRaiz = new AtendimentoRaiz(cmd.UsuarioId.Value, cmd.EstabelecimentoId.Value, cmd.Categoria.Value, paciente.Id);
            if (cmd.Atendimentos.Any(a => a.Tipo == TipoAtendimento.AlteracaoProntuario))
                atendimentoRaiz.AtualizacaoPronturarioImediata = true;
            atendimentosCriados.Add(atendimentoRaiz);

            foreach (var atd in cmd.Atendimentos)
            {
                //var atendimento = Atendimento.Criar(
                //    cmd.UsuarioId.Value,
                //    cmd.EstabelecimentoId.Value,
                //    cmd.Categoria.Value,
                //    paciente.Id,
                //    atd.Tipo.Value,
                //    atd.ProfissionalId,
                //    atd.ServicoId,
                //    atd.Justificativa);
                //atd.AtendimentoId = atendimento.Id;
                //atendimentosCriados.Add(atendimentoRaiz);

                //TODO: se for um atendimento odontológico, pegar o último odontograma
                //TODO: Pegar a equipe...
            }

            await container.Atendimentos.InsertMany(atendimentosCriados);

            //TODO: incluir na fila de atendimento
            //TODO: incluir notificações
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
                }
            });
            if (estabelecimento == null)
                throw new PulsarException(PulsarErrorCode.NotFound);
            return estabelecimento;
        }

        private async Task<bool> AlteracaoProntuarioExiste(CriarAtendimentoCommand cmd, Common.Container container)
        {
            if (cmd.Atendimentos.Any(a => a.Tipo == TipoAtendimento.AlteracaoProntuario))
            {
                //verifica se já existe
                var ap = await container.Atendimentos.AsQueryable()
                    .OfType<AlteracaoProntuario>()
                    .Where(x => x.Data == DateTime.Today && x.ProfissionalId == cmd.UsuarioId.Value && x.EstabelecimentoId == cmd.EstabelecimentoId)
                    .Select(x => new AlteracaoProntuario() { Id = x.Id })
                    .FirstOrDefaultAsync();
                if (ap != null)
                {
                    cmd.Atendimentos.First().AtendimentoId = ap.Id;
                    var justificativa = cmd.Atendimentos.First().Justificativa;
                    //atualiza a justificativa
                    await container.Atendimentos.UpdateOne(x => x.Id == ap.Id, new
                    {
                        Justificativa = justificativa
                    });
                    //não recriamos a alteração de prontuário..;
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
                    DadosAtuais = p.DadosAtuais
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
