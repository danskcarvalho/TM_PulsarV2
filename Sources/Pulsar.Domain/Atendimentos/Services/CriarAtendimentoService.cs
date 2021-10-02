using MongoDB.Bson;
using Pulsar.Common;
using Pulsar.Common.Enumerations;
using Pulsar.Common.Exceptions;
using Pulsar.Common.Services;
using Pulsar.Contracts.Atendimentos.Commands;
using Pulsar.Domain.Atendimentos.Models;
using Pulsar.Domain.Common;
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

            var paciente = await TratarPaciente(cmd, container);

            Dictionary<ObjectId, Servico> servicos = new();

            foreach (var atd in cmd.Atendimentos)
            {
                if (atd.ServicoId != null)
                {
                    if (servicos.ContainsKey(atd.ServicoId.Value))
                        continue;
                    Servico serv = await container.Servicos.FindOneById(atd.ServicoId.Value);
                    if (serv == null)
                        throw new PulsarException(PulsarErrorCode.NotFound);
                    
                    var idade = paciente.GetIdade().TotalDias;
                    if (serv.Restricoes != null)
                    {
                        if (!serv.Restricoes.Sexo.Permite(paciente.DadosAtuais.DadosBasicos.Sexo))
                            throw new PulsarException(PulsarErrorCode.BadRequest, $"O sexo do paciente não é compatível com o serviço {serv.Nome}.");

                        if (serv.Restricoes.IdadeMinimaEmDias != null && idade < serv.Restricoes.IdadeMinimaEmDias)
                            throw new PulsarException(PulsarErrorCode.BadRequest, $"A idade do paciente não é compatível com o serviço {serv.Nome}.");

                        if (serv.Restricoes.IdadeMaximaEmDias != null && idade > serv.Restricoes.IdadeMinimaEmDias)
                            throw new PulsarException(PulsarErrorCode.BadRequest, $"A idade do paciente não é compatível com o serviço {serv.Nome}.");
                    }

                    servicos[atd.ServicoId.Value] = serv;
                }
            }



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
