using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rb.dal.Models;

[Index("Username", Name = "UQ__Users__536C85E4DAB2AD31", IsUnique = true)]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(64)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Salt { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string? FullName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(50)]
    public string? Location { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    [InverseProperty("User")]
    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    [InverseProperty("User")]
    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();

    [InverseProperty("User")]
    public virtual ICollection<Template> Templates { get; set; } = new List<Template>();

    [InverseProperty("User")]
    public virtual ICollection<UserLanguage> UserLanguages { get; set; } = new List<UserLanguage>();

    [InverseProperty("User")]
    public virtual ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();

    [InverseProperty("User")]
    public virtual ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
}
