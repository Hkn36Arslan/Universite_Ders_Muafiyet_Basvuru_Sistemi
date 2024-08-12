using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MuafiyetProjesi2024.Models;

public partial class Kullanici
{
    public string? Mail { get; set; }
    
    public string? Parola { get; set; }
    
    [Key]
    public string Tckimlik { get; set; }

    public Basvuru Basvuru { get; set; }

    public List<Ders> Ders { get; set; }

    public Evrak Evrak { get; set; }
}
