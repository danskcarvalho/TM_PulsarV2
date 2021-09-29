using Pulsar.Common.Enumerations;
using Pulsar.Domain.Comum;
using Pulsar.Domain.Pastas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class PrescricaoExameResultado
    {
        /// <summary>
        /// Atendimento que informou o resultado.
        /// </summary>
        public virtual AtendimentoResumido AtendimentoGerador { get; set; }
        public virtual DateTime? DataRealizacao { get; set; }
        public virtual DateTime? DataDoResultado { get; set; }
        public virtual decimal? ResultadoNumerico { get; set; }
        public virtual ResultadoEspecifico? ResultadoEspecifico { get; set; }
        public virtual string Observacoes { get; set; }
        public List<PastaArquivo> Arquivos { get; set; }
        public DataRegistro DataRegistro { get; set; }
    }
}
