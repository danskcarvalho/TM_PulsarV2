using MongoDB.Bson;
using System;

namespace Pulsar.Common
{
    public static class Constants
    {
        public const int MaxRetriesOnTransientFailure = 2;

        public static class CollectionNames
        {
            public const string Procedimentos = "Procedimentos";
            public const string Especialidades = "Especialidades"; 
            public const string Jobs = "_Jobs";
            public const string ChavesCondicaoSaude = "ChavesCondicaoSaude";
            public const string Dentes = "Dentes";
            public const string Diagnosticos = "Diagnosticos";
            public const string Etnias = "Etnias";
            public const string Ineps = "Ineps";
            public const string Materiais = "Materiais";
            public const string PerguntasPuericultura = "PerguntasPuericultura";
            public const string Regioes = "Regioes";
            public const string PrincipiosAtivos = "PrincipiosAtivos";
            public const string Acompanhamentos = "Acompanhamentos";
            public const string Agendamentos = "Agendamentos";
            public const string Agendas = "Agendas";
            public const string Atendimentos = "Atendimentos";
            public const string Escalas = "Escalas";
            public const string Estabelecimentos = "Estabelecimentos";
            public const string Exportacoes = "Exportacoes";
            public const string Familias = "Familias";
            public const string FichasEsus = "FichasEsus";
            public const string FilasAtendimentos = "FilasAtendimentos";
            public const string Importacoes = "Importacoes";
            public const string Notificacoes = "Notificacoes";
            public const string Pacientes = "Pacientes";
            public const string Pastas = "Pastas";
            public const string Perfis = "Perfis";
            public const string ProcedimentosOdontologicos = "ProcedimentosOdontologicos";
            public const string Prontuarios = "Prontuarios";
            public const string RedesEstabelecimentos = "RedesEstabelecimentos";
            public const string Servicos = "Servicos";
            public const string Usuarios = "Usuarios";
        }

        public static class EmailTemplates
        {
            public const string ActivateAccount = "ActivateAccount";
            public const string ResetPassword = "ResetPassword";

            public class ActivateAccountModel
            {
                public string Codigo { get; set; }
            }

            public class ResetPasswordModel
            {
                public string Codigo { get; set; }
            }
        }

        public static class ObjectIds
        {
            public static readonly ObjectId Todos = ObjectId.Parse("6157160aaa427233695d20cc");
            public static readonly ObjectId UsuarioLogado = ObjectId.Parse("61571628aa427233695d20ce");
        }
    }
}
