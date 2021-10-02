using Pulsar.Domain.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Usuarios.Models
{
    public class UsuarioEspecialidade
    {
        public EspecialidadeResumida Especialidade { get; set; }
        public ConselhoProfissional Conselho { get; set; }
    }
}
