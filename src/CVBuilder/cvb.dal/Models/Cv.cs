using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace cvb.dal.Models;

[Table("CV")]
public partial class Cv
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Cvs")]
    public virtual User? User { get; set; }
}
