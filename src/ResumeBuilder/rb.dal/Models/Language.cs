using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rb.dal.Models;

[Index("Name", Name = "UQ__Language__737584F68DF066D5", IsUnique = true)]
public partial class Language
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Language")]
    public virtual ICollection<UserLanguage> UserLanguages { get; set; } = new List<UserLanguage>();
}
