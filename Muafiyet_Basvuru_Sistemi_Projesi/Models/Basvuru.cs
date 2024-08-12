using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuafiyetProjesi2024.Models;

public partial class Basvuru
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BasvuruId { get; set; }

    public string? AdSoyad { get; set; }

    public string? Tckimlik { get; set; }

    public string? OgrNo { get; set; }

    public string? Tel { get; set; }

    public string? Mail { get; set; }

    public string? KayitTur { get; set; }

    public string? GeldigiUni { get; set; }

    public string? GeldigiFak { get; set; }

    public string? GeldigiBolum { get; set; }

    public string? BolumBaskanligi { get; set; }

    public Kullanici? Kullanici { get; set; }
}
