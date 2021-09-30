using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum TipoDiagnostico
    {
        [Display(Name = "CID10")]
        CID10 = 1,
        [Display(Name = "CIAP2")]
        CIAP2 = 2,
        [Display(Name = "NANDA")]
        NANDA = 3
    }
}
