using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum EstabelecimentoTipo
    {
        [Display(Name = "POSTO DE SAÚDE")]
        PostoSaude = 1,
        [Display(Name = "CENTRO DE SAÚDE/UNIDADE BÁSICA DE SAÚDE")]
        CentroSaudeUnidadeBasicaSaude = 2,
        [Display(Name = "POLICLÍNICA")]
        Policlina = 4,
        [Display(Name = "HOSPITAL GERAL")]
        HospitalGeral = 5,
        [Display(Name = "HOSPITAL ESPECIALIZADO")]
        HospitalEspecializado = 7,
        [Display(Name = "UNIDADE MISTA")]
        UnidadeMista = 15,
        [Display(Name = "PRONTO SOCORRO GERAL")]
        ProntoSocorroGeral = 20,
        [Display(Name = "PRONTO SOCORRO ESPECIALIZADO")]
        ProntoSocorroEspecializado = 21,
        [Display(Name = "CONSULTÓRIO ISOLADO")]
        ConsultorioIsolado = 22,
        [Display(Name = "UNIDADE MÓVEL FLUVIAL")]
        UnidadeMovelFluvial = 32,
        [Display(Name = "CLÍNICA ESPECIALIZADA/AMBULATÓRIO ESPECIALIZADO")]
        ClinicaEspecializadaAmbulatorioEspecializado = 36,
        [Display(Name = "UNIDADE DE SERVIÇO DE APOIO DE DIAGNOSE E TERAPIA")]
        UnidadeServicoApoioDiagnoseTerapia = 39,
        [Display(Name = "UNIDADE MÓVEL TERRESTRE")]
        UnidadeMovelTerrestre = 40,
        [Display(Name = "UNIDADE MÓVEL DE NÍVEL PRÉ-HOSPITALAR NA ÁREA DE URGÊNCIA")]
        UnidadeMovelPreHospitalarUrgencia = 42,
        [Display(Name = "FARMÁCIA")]
        Farmacia = 43,
        [Display(Name = "UNIDADE DE VIGILÂNCIA EM SAÚDE")]
        UnidadeVigilanciaSaude = 50,
        [Display(Name = "COOPERATIVA")]
        Cooperativa = 60,
        [Display(Name = "CENTRO DE PARTO NORMAL ISOLADO")]
        CentroPartoNormalIsolado = 61,
        [Display(Name = "HOSPITAL/DIA ISOLADO")]
        HospitalDiaIsolado = 62,
        [Display(Name = "CENTRAL DE REGULAÇÃO DE SERVIÇOS DE SAÚDE")]
        CentralRegulacaoServicosSaude = 64,
        [Display(Name = "LABORATÓRIO CENTRAL DE SAÚDE PÚBLICA - LACEN")]
        Lacen = 67,
        [Display(Name = "SECRETÁRIA DA SAÚDE")]
        SecretariaSaude = 68,
        [Display(Name = "CENTRO DE ATENÇÃO HEMOTERAPICA E OU HEMATOLOGICA")]
        CentroAtencaoHemoterapica = 69,
        [Display(Name = "CENTRO DE ATENÇÃO PSICOSSOCIAL")]
        CentroAtencaoPsicossocial = 70,
        [Display(Name = "CENTRO DE APOIO A SAÚDE DA FAMÍLIA")]
        CentroApoioSaudeFamilia = 71,
        [Display(Name = "UNIDADE DE ATENÇÃO A SAÚDE INDIGENA")]
        UnidadeSaudeIndigine = 72,
        [Display(Name = "PRONTO ATENDIMENTO")]
        ProntoAtendimento = 73,
        [Display(Name = "POLO ACADEMIA DA SAÚDE")]
        PoloAcademiaSaude = 74,
        [Display(Name = "TELESAÚDE")]
        Telesaude = 75,
        [Display(Name = "CENTRAL DE REGULAÇÃO MÉDICA DE URGÊNCIAS")]
        CentralRegulacaoUrgencias = 76,
        [Display(Name = "SERVIÇO DE ATENÇÃO DOMICILIAR ISOLADO (HOME CARE)")]
        HomeCare = 77,
        [Display(Name = "UNIDADE DE ATENÇÃO EM REGIME RESIDENCIAL")]
        UnidadeRegimeResidencial = 78,
        [Display(Name = "OFICINA ORTOPÉDICA")]
        OficinaOrtopedia = 79,
        [Display(Name = "LABORATÓRIO DE SAÚDE PÚBLICA")]
        LaboratorioSaudePublica = 80,
        [Display(Name = "CENTRAL DE REGULAÇÃO DO ACESSO")]
        CentralRegulacaoAcesso = 81,
        [Display(Name = "CENTRAL DE NOTIFICAÇÃO, CAPTAÇÃO E DISTRIBUIÇÃO DE ÓRGÃOS ESTADUAL")]
        CentralNotificacaoEstadual = 82,
        [Display(Name = "POLO DE PREVENÇÃO DE DOENÇAS E AGRAVOS E PROMOÇÃO DA SAÚDE")]
        PoloPrevencaoDoencas = 83,
        [Display(Name = "CENTRAL DE ABASTECIMENTO")]
        CentralAbastacimento = 84,
        [Display(Name = "CENTRO DE IMUNIZAÇÃO")]
        CentroImunizacao = 85,
    }
}
