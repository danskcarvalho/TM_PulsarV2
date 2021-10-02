using Pulsar.Common.Enumerations;
using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Atendimentos.Models
{
    public class Odontograma
    {
        public List<OdontogramaDente> Dentes { get; set; }
    }

    public class OdontogramaDente
    {
        public DenteResumido Dente { get; set; }
        public RegiaoCoroa Coroa { get; set; }
        public RegiaoRaiz Raiz { get; set; }

        public class RegiaoCoroa
        {
            public SubRegiaoCoroa Mesial { get; set; }
            public SubRegiaoCoroa Distal { get; set; }
            public SubRegiaoCoroa LingualPalatalina { get; set; }
            public SubRegiaoCoroa OclusalIncisal { get; set; }
            public SubRegiaoCoroa Vestibular { get; set; }
        }
        public class SubRegiaoCoroa
        {
            public List<ProblemaCoroaDente> Problemas { get; set; }
        }
        public class RegiaoRaiz
        {
            public List<ProblemaRaiz> Problemas { get; set; }
        }
        public class ProblemaCoroa
        {
            public ProblemaCoroaDente Problema { get; set; }
            public bool Resolvido { get; set; }
        }
        public class ProblemaRaiz
        {
            public ProblemaRaizDente Problema { get; set; }
            public bool Resolvido { get; set; }
        }
    }
}
