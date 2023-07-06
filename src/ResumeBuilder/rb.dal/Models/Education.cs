using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rb.dal.Models;

[Table("Education")]
public partial class Education
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Place { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime FromDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? ToDate { get; set; }

    [InverseProperty("Education")]
    public virtual ICollection<EducationSkill> EducationSkills { get; set; } = new List<EducationSkill>();
}
