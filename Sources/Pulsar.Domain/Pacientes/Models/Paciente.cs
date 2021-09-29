using MongoDB.Bson;
using Pulsar.Domain.Comum;
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
        public DataRegistro DataRegistro { get; set; }
        public long DataVersion { get; set; }
    }
}
