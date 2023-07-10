using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rb.dal.Models;

public partial class EducationSkill
{
    [Key]
    public int Id { get; set; }

    public int? EducationId { get; set; }

    public int? SkillId { get; set; }

    [ForeignKey("EducationId")]
    [InverseProperty("EducationSkills")]
    public virtual Education? Education { get; set; }

    [ForeignKey("SkillId")]
    [InverseProperty("EducationSkills")]
    public virtual Skill? Skill { get; set; }
}
