using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum ReadPref
    {
        SecondaryPreferred,
        Secondary,
        PrimaryPreferred,
        Primary,
        Nearest
    }
}
