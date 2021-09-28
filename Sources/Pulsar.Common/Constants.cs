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
        }
    }
}
