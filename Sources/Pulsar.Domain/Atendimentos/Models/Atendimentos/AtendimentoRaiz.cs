using Pulsar.Common.Enumerations;
using Pulsar.Domain.Comum;
using Pulsar.Domain.Prontuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtendimentoRaiz : Atendimento
    {
        public AtendimentoRaiz()
        {
            Tipo = TipoAtendimento.Raiz;
        }

        public List<AtendimentoEvento> Eventos { get; set; }
        public LocalAtendimento Local { get; set; }
        public Endereco Endereco { get; set; }
        public ModalidadeAD? ModalidadeAD { get; set; }
        public CategoriaAtendimento Categoria { get; set; }
        public RegistroEvasao RegistroEvasao { get; set; }
        public RiscoAtendimento? Risco { get; set; }
        public StatusAtendimentoRaiz Status { get; set; }
        public List<Atividade> Atividades { get; set; }
        public List<ArtefatoAtendimento> Artefatos { get; set; }
        public List<FragmentoProntuarioDados> AlteracoesProntuario { get; set; }
        public bool AtualizacaoPronturarioImediata { get; set; }
    }
}
