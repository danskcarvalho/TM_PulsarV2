using Pulsar.Common.Enumerations;
using Pulsar.Domain.ChavesCondicaoSaude.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Prontuario.Models
{
    public class CondicaoSaudeProntuario : ProntuarioDados
    {
        public virtual ChaveCondicaoSaudeResumida ChaveCondicaoSaude { get; set; }
        public virtual DateTime? DataInicial { get; set; }
        public virtual DateTime? DataFinal { get; set; }
        public virtual int? IdadeInicialEmDias { get; set; }
        public virtual int? IdadeFinalEmDias { get; set; }
        public virtual string Observacoes { get; set; }
        public virtual StatusCondicaoSaude Status { get; set; }
    }
}
