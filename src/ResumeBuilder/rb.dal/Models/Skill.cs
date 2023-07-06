using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rb.dal.Models;

public partial class Skill
{
    [Key]
    public int Id { get; set; }

    [Column("Skill")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Skill1 { get; set; }

    [InverseProperty("Skill")]
    public virtual ICollection<EducationSkill> EducationSkills { get; set; } = new List<EducationSkill>();
}
