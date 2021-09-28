using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum ModalidadeAD
    {
        [Display(Name = "AD 1")]
        AD1 = 1,
        [Display(Name = "AD 2")]
        AD2 = 2,
        [Display(Name = "AD 3")]
        AD3 = 3,
        [Display(Name = "Inelegível")]
        Inelegivel = 4
    }
}
