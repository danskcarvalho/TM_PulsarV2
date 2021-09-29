﻿using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class MedicaoGlicemia
    {
        public decimal? GlicemiaCapilar { get; set; }
        public GlicemiaMomentoColeta? MomentoColeta { get; set; }
    }
}
