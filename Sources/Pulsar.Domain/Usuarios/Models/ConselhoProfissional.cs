using Pulsar.Domain.Regioes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Usuarios.Models
{
    public class ConselhoProfissional
    {
        public string NumeroConselho { get; set; }
        public string Conselho { get; set; }
        public EstadoResumido EstadoEmissor { get; set; }
    }
}
