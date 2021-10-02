using Pulsar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Pacientes.Models
{
    public class PacienteHistorico
    {
        public Endereco Endereco { get; set; }
        public DadosBasicos DadosBasicos { get; set; }
        public DadosNacionalidade DadosNacionalidade { get; set; }
        public Contatos Contatos { get; set; }
        public DadosFinanceiros DadosFinanceiros { get; set; }
        public CaracteristicasFisicas CaracteristicasFisicas { get; set; }
        public EducacaoFamilia EducacaoFamilia { get; set; }
        public DataRegistro DataRegistro { get; set; }
    }
}
