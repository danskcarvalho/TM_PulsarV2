﻿using MongoDB.Bson;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AlteracaoProntuario : AtendimentoComProfissional
    {
        public AlteracaoProntuario()
        {
            Tipo = Pulsar.Common.Enumerations.TipoAtendimento.AlteracaoProntuario;
        }

        public AlteracaoProntuario(ObjectId usuarioId, ObjectId atendimentoRaizId, ObjectId estabelecimentoId, ObjectId pacienteId, Usuario profissional,
            string justificativa) : this()
        {
            EstabelecimentoId = estabelecimentoId;
            PacienteId = pacienteId;
            Id = ObjectId.GenerateNewId();
            Status = StatusAtendimento.Aguardando;
            EstabelecimentoId = estabelecimentoId;
            PacienteId = pacienteId;
            FichasEsus = new List<ObjectId>();
            DataRegistro = Common.DataRegistro.CriadoHoje(usuarioId);
            ProfissionalId = profissional.Id;
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
            Especialidade = profissional.GetLotacao(estabelecimentoId).EspecialidadeConselho.Especialidade;
            ConselhoProfissional = profissional.GetLotacao(estabelecimentoId).EspecialidadeConselho.Conselho;
            ProcedimentosReportados = new List<ProcedimentoReportado>();
            Documentos = new List<Pastas.Models.PastaArquivo>();
            Acompanhamentos = new List<ObjectId>();
            Data = DateTime.Today;
            Justificativa = justificativa;
        }

        public DateTime Data { get; set; }
        public string Justificativa { get; set; }
    }
}
