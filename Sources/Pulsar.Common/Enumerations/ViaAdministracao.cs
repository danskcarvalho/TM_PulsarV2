using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum ViaAdministracao
    {
        [Display(Name = "Oral")]
        Oral = 1,
        [Display(Name = "Sublingual")]
        Sublingual = 2,
        [Display(Name = "Retal")]
        Retal = 3,
        [Display(Name = "Intradérmica")]
        Intradermica = 4,
        [Display(Name = "Subcutânea")]
        Subcutanea = 5,
        [Display(Name = "Intramuscular")]
        Intramuscular = 6,
        [Display(Name = "Endovenosa")]
        Endovenosa = 7,
        [Display(Name = "Respiratória")]
        Respiratoria = 8,
        [Display(Name = "Ocular")]
        Ocular = 9,
        [Display(Name = "Intranasal")]
        Intranasal = 10,
        [Display(Name = "Auricular")]
        Auricular = 11,
        [Display(Name = "Vaginal")]
        Vaginal = 12,
        [Display(Name = "Parental")]
        Parental = 13,
        [Display(Name = "Local")]
        Local = 14,
        [Display(Name = "Outros")]
        Outros = 15,
        [Display(Name = "Bucal")]
        Bucal = 16,
        [Display(Name = "Capilar")]
        Capilar = 17,
        [Display(Name = "Dermatológica")]
        Dermatologica = 18,
        [Display(Name = "Epidural")]
        Epidural = 19,
        [Display(Name = "Inalatória por via nasal")]
        InalatoriaViaNasal = 20,
        [Display(Name = "Inalatória por via oral")]
        InalatoriaViaOral = 21,
        [Display(Name = "Intra-arterial")]
        IntraArterial = 22,
        [Display(Name = "Intra-articular")]
        IntraArticular = 23,
        [Display(Name = "Intratecal")]
        Intratecal = 24,
        [Display(Name = "Intrauterina")]
        Intrauterina = 25,
        [Display(Name = "Irrigação")]
        Irrigacao = 26,
        [Display(Name = "Nasal")]
        Nasal = 27,
        [Display(Name = "Otológica")]
        Otologica = 28,
        [Display(Name = "Transdérmica")]
        Transdermica = 29,
        [Display(Name = "Uretral")]
        Uretral = 30,
        [Display(Name = "Inalatória")]
        Inalatoria = 31,
        [Display(Name = "Intramuscular Profunda")]
        IntramuscularProfunda = 32
    }
}
