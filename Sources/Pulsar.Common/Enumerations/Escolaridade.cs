using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum Escolaridade
    {
        [Display(Name = "Não sabe ler/Escrever")]
        NaoSabeLerOuEscrever = 1,
        [Display(Name = "Alfabetizado(a)")]
        Alfabetizada = 2,
        [Display(Name = "1º Grau Incompleto")]
        PrimGrauIncompleto = 3,
        [Display(Name = "1º Grau Completo")]
        PrimGrauCompleto = 4,
        [Display(Name = "2º Grau Incompleto")]
        SegGrauIncompleto = 5,
        [Display(Name = "2º Grau Completo")]
        SegGrauCompleto = 6,
        [Display(Name = "Superior Incompleto")]
        SuperiorIncompleto = 7,
        [Display(Name = "Superior Completo")]
        SuperiorCompleto = 8,
        [Display(Name = "Especialização/Residência")]
        EspecializacaoResidencia = 9,
        [Display(Name = "Mestrado")]
        Mestrado = 10,
        [Display(Name = "Doutorado")]
        Doutorado = 11,
        [Display(Name = "Sem Informação")]
        SemInformacao = 12
    }
}
