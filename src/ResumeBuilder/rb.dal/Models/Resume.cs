using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rb.dal.Models;

[Table("Resume")]
public partial class Resume
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TemplateId { get; set; }

    [ForeignKey("TemplateId")]
    [InverseProperty("Resumes")]
    public virtual Template Template { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Resumes")]
    public virtual User User { get; set; } = null!;
}
