using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuafiyetProjesi2024.Models;

public partial class Ders
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DersId { get; set; }
    public string? Tckimlik { get; set; }

    public string? OncekiDersAdi { get; set; }

    public int? OncekiDersKredisi { get; set; }

    public int? OncekiDersAkts { get; set; }

    public string? MuafDersAdi { get; set; }

    public int? MuafDersKredisi { get; set; }

    public int? MuafDersAkts { get; set; }

    public string? MuafDersKodu { get; set; }

    public string? OncekiDersKodu { get; set; }

    public Kullanici? Kullanici { get; set; }
}
