using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rb.dal.Models;

public partial class Language
{
    [Key]
    public int Id { get; set; }

    [Column("Language")]
    [StringLength(50)]
    [Unicode(false)]
    public string Language1 { get; set; } = null!;

    [InverseProperty("Language")]
    public virtual ICollection<UserLanguage> UserLanguages { get; set; } = new List<UserLanguage>();
}
