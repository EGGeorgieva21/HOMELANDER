using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rb.dal.Models;

public partial class Template
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    [InverseProperty("Template")]
    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();

    [ForeignKey("UserId")]
    [InverseProperty("Templates")]
    public virtual User? User { get; set; }
}
