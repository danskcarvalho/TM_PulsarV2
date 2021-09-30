using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum MotivoCancelamento
    {
        [Display(Name = "Pelo Estabelecimento")]
        PeloEstabelecimento = 1,
        [Display(Name = "Pelo Cidadão")]
        PeloCidadao = 2,
        [Display(Name = "Faltoso")]
        Faltoso = 3,
        [Display(Name = "Desistência")]
        Desistencia = 4,
        [Display(Name = "Outro Motivo")]
        OutroMotivo = 5
    }
}
