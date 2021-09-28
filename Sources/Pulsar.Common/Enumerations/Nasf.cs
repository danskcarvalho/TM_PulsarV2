using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum Nasf
    {
        [Display(Name = "Avaliação / Diagnóstico")]
        AvaliacaoDiagnostico = 1,
        [Display(Name = "Procedimentos clínicos terapêuticos")]
        ProcedimentosClinicosTerapeuticos = 2,
        [Display(Name = "Prescrição terapêutica")]
        PrescricaoTerapeutica = 3
    }
}
