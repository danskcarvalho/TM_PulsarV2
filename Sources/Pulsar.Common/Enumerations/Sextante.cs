using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum Sextante 
    {
        [Display(Name = "S1 - Superior Posterior Direito (dentes 18 ao 14)")]
        SuperiorPosteriorDireito = 1,
        [Display(Name = "S2 - Superior Anterior (dentes 13 ao 23)")]
        SuperiorAnterior = 2,
        [Display(Name = "S3 - Superior Posterior Esquerdo (dentes 24 ao 28)")]
        SuperiorPosteriorEsquerdo = 3,
        [Display(Name = "S4 - Inferior Posterior Esquerdo (dentes 38 ao 34)")]
        InferiorPosteriorEsquerdo = 4,
        [Display(Name = "S5 - Inferior Anterior (dentes 33 ao 43)")]
        InferiorAnterior = 5,
        [Display(Name = "S6 - Inferior Posterior Direito (dentes 44 ao 48)")]
        InferiorPosteriorDireito = 6
    }
}
