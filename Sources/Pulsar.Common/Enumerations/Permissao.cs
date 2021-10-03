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
        GerenciarPerfis = 2,
        [Display(Name = "Criar Atendimento")]
        CriarAtendimento = 3,
        RealizarAtendimentoMedico = 4,
        RealizarAtendimentoEnfermagem = 5,
        RealizarAtendimentoAuxiliarEnfermagem = 6,
        RealizarAtendimentoVacinacao = 7,
        RealizarAtendimentoOdontologico = 8,
        AlterarProntuario = 9,
        RealizarEscutaInicial = 10
    }
}
