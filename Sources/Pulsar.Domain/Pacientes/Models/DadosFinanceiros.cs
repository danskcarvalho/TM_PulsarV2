using Pulsar.Domain.Comum;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Pacientes.Models
{
    public class DadosFinanceiros
    {
        public bool TrabalhaForaDeCasa { get; set; }
        public EspecialidadeResumida Ocupacao { get; set; }
        public int? HorasTrabalho { get; set; }
        public decimal? RendaFamiliar { get; set; }
        public int? PessoasVivendoComEssaRenda { get; set; }
        public bool? RealizaEsforcoFisico { get; set; }
        public bool? TemContatoProdutosQuimicos { get; set; }
        public string LocalTrabalho { get; set; }
        public Endereco LocalTrabalhoEndereco { get; set; }
    }
}
