using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rb.dal.Models;

public partial class UserLanguage
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int LanguageId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AdvanceLevel { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("UserLanguages")]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserLanguages")]
    public virtual User User { get; set; } = null!;
}
