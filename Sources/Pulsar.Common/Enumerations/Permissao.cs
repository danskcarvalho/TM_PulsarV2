using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum Permissao
    {
        [Display(Name = "Gerenciar Usuários")]
        GerenciarUsuarios = 1,
        [Display(Name = "Gerenciar Perfis")]
        GerenciarPerfis = 2
    }
}
