using MongoDB.Bson;
using Pulsar.Common;
using Pulsar.Common.Enumerations;
using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Pacientes.Models
{
    public class Paciente
    {
        public ObjectId Id { get; set; }
        public string TermosPesquisa { get; set; }
        public PacienteHistorico DadosAtuais { get; set; }
        public bool Anonimo { get; set; }
        public ObjectId? AntecedentesPessoais { get; set; }
        public ObjectId? AntecedentesFamiliares { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
        public List<PacienteHistorico> Historico { get; set; }

        public static Paciente CriarPacienteAnonimo(ObjectId usuarioId, string nome, Sexo sexo, DateTime dataNascimento)
        {
            var criadoHoje = DataRegistro.CriadoHoje(usuarioId);
            var p = new Paciente()
            {
                Id = ObjectId.GenerateNewId(),
                Anonimo = true,
                DadosAtuais = new PacienteHistorico()
                {
                    DadosBasicos = new DadosBasicos()
                    {
                        Nome = nome,
                        Sexo = sexo,
                        DataNascimento = dataNascimento
                    },
                    DataRegistro = criadoHoje
                },
                TermosPesquisa = nome.Tokenize(),
                DataRegistro = criadoHoje
            };
            p.AdicionarHistorico();

            return p;
        }

        private void AdicionarHistorico()
        {
            if (this.Historico == null)
                this.Historico = new List<PacienteHistorico>();

            this.Historico.Add(this.DadosAtuais);

            while (this.Historico.Count > 100)
                this.Historico.RemoveAt(1); //o primeiro histórico de criação é sempre mantido...
        }

        public Idade GetIdade()
        {
            return Idade.Calcular(this.DadosAtuais.DadosBasicos.DataNascimento);
        }
    }
}
