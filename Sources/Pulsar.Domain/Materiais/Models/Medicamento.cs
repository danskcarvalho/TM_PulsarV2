using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Materiais.Models
{
    public class Medicamento : Material
    {
        public Medicamento()
        {
            Tipo = TipoMaterial.Medicamento;
        }
        public string Denominacao { get; set; }
        public string Forma { get; set; }
        public string Concentracao { get; set; }
        public string CodigoEsus { get; set; }
        public PrincipioAtivoResumido PrincipioAtivo { get; set; }
        public List<MedicamentoUnidadeFornecimento> UnidadesFornecimento { get; set; }
    }
}
