using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum TipoParto
    {
        [Display(Name = "Normal")]
        Normal,
        [Display(Name = "Cesárea")]
        Cesarea
    }
}
