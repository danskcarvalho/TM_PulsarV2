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
        public Endereco Endereco { get; set; }
        public DadosBasicos DadosBasicos { get; set; }
        public DadosNacionalidade DadosNacionalidade { get; set; }
        public Contatos Contatos { get; set; }
        public DadosFinanceiros DadosFinanceiros { get; set; }
        public CaracteristicasFisicas CaracteristicasFisicas { get; set; }
        public EducacaoFamilia EducacaoFamilia { get; set; }
        public bool Anonimo { get; set; }
        public ObjectId? AntecedentesPessoais { get; set; }
        public ObjectId? AntecedentesFamiliares { get; set; }
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }

        public static Paciente CriarPacienteAnonimo(ObjectId usuarioId, string nome, Sexo sexo, DateTime dataNascimento)
        {
            var criadoHoje = DataRegistro.CriadoHoje(usuarioId);
            var p = new Paciente()
            {
                Id = ObjectId.GenerateNewId(),
                Anonimo = true,

                DadosBasicos = new DadosBasicos()
                {
                    Nome = nome,
                    Sexo = sexo,
                    DataNascimento = dataNascimento
                },
                DataRegistro = criadoHoje,
                TermosPesquisa = nome.Tokenize()
            };

            return p;
        }

        public Idade GetIdade()
        {
            return Idade.Calcular(this.DadosBasicos.DataNascimento);
        }
    }
}
