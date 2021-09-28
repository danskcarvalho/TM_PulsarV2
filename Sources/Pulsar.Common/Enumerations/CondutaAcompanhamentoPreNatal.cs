using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common.Enumerations
{
    public enum CondutaAcompanhamentoPreNatal
    {
        [Display(Name = "Orientação alimentar")]
        Conduta1 = 1,
        [Display(Name = "É recomendável tomar 20 minutos de sol, durante o início da manhã ou  o final da tarde, inclusive nas mamas. Lembre-se de usar boné ou chapéu e protetor solar no rosto, para evitar manchas de pele.")]
        Conduta2 = 2,
        [Display(Name = "Evite descolorantes, tinturas de cabelo, alisantes e onduladores que contêm amônia e outros componentes que podem fazer mal ao bebê.")]
        Conduta3 = 3,
        [Display(Name = "Orientação do convite ao companheiro(a)  para participar das consultas de pré-natal, caso seja de sua vontade.")]
        Conduta4 = 4,
        [Display(Name = "Indicar uma alimentação saudável : Alimentos mais naturais de origem vegetal devem ser a maior parte de sua alimentação. Feijões, cereais, legumes, verduras, frutas, castanhas, leites, carnes e ovos tornam a refeição balanceada e saborosa. Prefira os cereais integrais. + Indicações na caderneta da gestante (p. 9)")]
        Conduta5 = 5,
        [Display(Name = "Agendamento de consultas subsequentes.")]
        Conduta6 = 6,
        [Display(Name = "Encaminhamento odontológico")]
        Conduta7 = 7,
        [Display(Name = "Realização de ações e práticas educativas individuais e em grupos. Os grupos educativos para adolescentes devem ser exclusivos dessa faixa etária, abordando temas de interesse do grupo. Recomenda-se dividir os grupos em faixas de 10-14 anos e de 15-19 anos, para obtenção de melhores resultados")]
        Conduta8 = 8,
        [Display(Name = "Alguns momentos do dia, procure ficar mais tranquila para perceber as sensações de seu corpo. Coloque as mãos na barriga, feche os olhos e sinta o que está  acontecendo. Isso pode lhe trazer confiança e diminuir suas preocupações.")]
        Conduta9 = 9,
        [Display(Name = "Entrega da caderneta da gestante")]
        Conduta10 = 10,
        [Display(Name = "Indicar uma alimentação saudável : Faça pelo menos três refeições (café da manhã, almoço e jantar) e duas refeições menores por dia, evitando ficar muitas horas sem comer. Entre as refeições beba água. + Indicações na caderneta da gestante (p. 9)")]
        Conduta11 = 11,
        [Display(Name = "Você deve sair de ambientes onde haja fumantes, em qualquer fase da gravidez. Respirar a fumaça com frequência pode afetar o bebê")]
        Conduta12 = 12
    }
}
