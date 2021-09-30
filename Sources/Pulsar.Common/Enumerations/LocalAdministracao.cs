using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum LocalAdministracao
    {
        [Display(Name = "Boca")]
        Boca = 1,
        [Display(Name = "Deltóide Direito")]
        DeltoideDireito = 2,
        [Display(Name = "Deltóide Esquerdo")]
        DeltoideEsquerdo = 3,
        [Display(Name = "Dorso Glúteo Direito")]
        DorsoGluteoDireito = 4,
        [Display(Name = "Dorso Glúteo Esquerdo")]
        DorsoGluteoEsquerdo = 5,
        [Display(Name = "Face Anterolateral Externa da Coxa Direita")]
        FaceAnterolateralExternaCoxaDireita = 6,
        [Display(Name = "Face Anterolateral Externa da Coxa Esquerda")]
        FaceAnterolateralExternaCoxaEsquerda = 7,
        [Display(Name = "Face Anterolateral Externa do Braço Direito")]
        FaceAnterolateralExternaBracoDireito = 8,
        [Display(Name = "Face Anterolateral Externa do Braço Esquerdo")]
        FaceAnterolateralExternaBracoEsquerdo = 9,
        [Display(Name = "Face Anterolateral Externa do Antebraço Direito")]
        FaceAnterolateralExternaAntebracoDireito = 10,
        [Display(Name = "Face Anterolateral Externa do Antebraço Esquerdo")]
        FaceAnterolateralExternaAntebracoEsquerdo = 11,
        [Display(Name = "Face Externa Inferior do Braço Direito")]
        FaceExternaInferiorBracoDireito = 12,
        [Display(Name = "Face Externa Inferior do Braço Esquerdo")]
        FaceExternaInferiorBracoEsquerdo = 13,
        [Display(Name = "Face Externa Superior do Braço Direito")]
        FaceExternaSuperiorBracoDireito = 14,
        [Display(Name = "Face Externa Superior do Braço Esquerdo")]
        FaceExternaSuperiorBracoEsquerdo = 15,
        [Display(Name = "Outro")]
        Outro = 16,
        [Display(Name = "Rede Venosa")]
        RedeVenosa = 17,
        [Display(Name = "Vasto Lateral da Coxa Direita")]
        VastoLateralCoxaDireita = 18,
        [Display(Name = "Vasto Lateral da Coxa Esquerda")]
        VastoLateralCoxaEsquerda = 19,
        [Display(Name = "Ventro Glúteo Direito")]
        VentroGluteoDireito = 20,
        [Display(Name = "Ventro Glúteo Esquerdo")]
        VentroGluteoEsquerdo = 21
    }
}
