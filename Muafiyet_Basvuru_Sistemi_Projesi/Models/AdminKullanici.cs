using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MuafiyetProjesi2024.Models;

public partial class AdminKullanici
{
    public string? AdSoyad { get; set; }

    public string? Sifre { get; set; }

    public string? BolumBilgisi { get; set; }

    public string? Yetkisi { get; set; }

    
    public string? Mail { get; set; }
    
    [Key]
    public int AdminKullaniciId { get; set; }


}
