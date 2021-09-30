﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pulsar.Common.Enumerations
{
    public enum DoseTipo
    {
        [Display(Name = "Âmpola")]
        Ampola = 1,
        [Display(Name = "Barra")]
        Barra = 2,
        [Display(Name = "Bastão")]
        Bastao = 3,
        [Display(Name = "Bisnaga")]
        Bisnaga = 4,
        [Display(Name = "Blíster")]
        Blister = 5,
        [Display(Name = "Bolsa")]
        Bolsa = 6,
        [Display(Name = "Caixa")]
        Caixa = 7,
        [Display(Name = "Cápsula")]
        Capsula = 8,
        [Display(Name = "Carpule")]
        Carpule = 9,
        [Display(Name = "Cartão")]
        Cartao = 10,
        [Display(Name = "Cartela")]
        Cartela = 11,
        [Display(Name = "Comprimido")]
        Comprimido = 12,
        [Display(Name = "Dose")]
        Dose = 13,
        [Display(Name = "Drágea")]
        Dragea = 14,
        [Display(Name = "Envelope")]
        Envelope = 15,
        [Display(Name = "Flaconete")]
        Flaconete = 16,
        [Display(Name = "Frasco")]
        Frasco = 17,
        [Display(Name = "Frasco-Âmpola")]
        FrascoAmpola = 18,
        [Display(Name = "Lata")]
        Lata = 19,
        [Display(Name = "Miligrama")]
        Miligrama = 20,
        [Display(Name = "Mililitro")]
        Mililitro = 21,
        [Display(Name = "Óvulo")]
        Ovulo = 22,
        [Display(Name = "Pastilha")]
        Pastilha = 23,
        [Display(Name = "Pote")]
        Pote = 24,
        [Display(Name = "Sachê")]
        Sache = 25,
        [Display(Name = "Seringa")]
        Seringa = 26,
        [Display(Name = "Supositório")]
        Supositorio = 27,
        [Display(Name = "Tablete")]
        Tablete = 28,
        [Display(Name = "Tubeta")]
        Tubete = 29,
        [Display(Name = "Tubo")]
        Tubo = 30,
        [Display(Name = "Unidade")]
        Unidade = 31,
        [Display(Name = "Gota")]
        Gota = 32
    }
}
