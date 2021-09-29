using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class AtestadoComparecimento : ArtefatoAtendimento
    {
        public AtestadoComparecimento()
        {
            Tipo = Common.Enumerations.ArtefatoAtendimentoTipo.AtestadoComparecimento;
        }

        public virtual string NomeCidadao { get; set; }
        public virtual string CpfCidadao { get; set; }
        public virtual DateTime DataComparecimento { get; set; }
        public virtual TimeSpan HorarioEntrada { get; set; }
        public virtual TimeSpan HorarioSaida { get; set; }
        public virtual bool Acompanhante { get; set; }
    }
}
