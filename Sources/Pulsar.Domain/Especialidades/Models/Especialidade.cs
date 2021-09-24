using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Domain.Especialidades.Models
{
    public class Especialidade
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public  string Codigo { get; set; }
        public  string Nome { get; set; }
        public  bool GeraFichaCadastroIndividual { get; set; }
        public  bool GeraFichaCadastroDomiciliarTerritorial { get; set; }
        public  bool GeraFichaAtendimentoIndividual { get; set; }
        public  bool GeraFichaProcedimentos { get; set; }
        public  bool GeraFichaAtendimentoOdontologicoIndividual { get; set; }
        public  bool GeraFichaAtividadeColetiva { get; set; }
        public  bool GeraFichaVacinacao { get; set; }
        public  bool GeraFichaVisitaDomiciliarTerritorial { get; set; }
        public  bool GeraFichaMarcadoresConsumoAlimentar { get; set; }
        public  bool GeraFichaAvaliacaoElegibilidade { get; set; }
        public  bool GeraFichaAtendimentoDomiciliar { get; set; }
        public  bool GeraFichaComplementarZikaMicrocefalia { get; set; }
        public string TermosPesquisa { get; set; }
        public bool Ativo { get; set; }
    }
}
