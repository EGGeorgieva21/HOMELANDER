using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rb.dal.Models;

public partial class Certificate
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [Column(TypeName = "date")]
    public DateTime IssuedDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? ExpirationDate { get; set; }
}
