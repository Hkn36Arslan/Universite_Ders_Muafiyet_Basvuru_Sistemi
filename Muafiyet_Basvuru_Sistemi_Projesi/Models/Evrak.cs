using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuafiyetProjesi2024.Models;

public partial class Evrak
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EvrakId { get; set; }

    public string? Transkript { get; set; }

    public string? DersIcerik { get; set; }

    public string? Tckimlik { get; set; }

    public string? BasvuruBelgesi { get; set; }

    public  Kullanici? Kullanici { get; set; }
}
