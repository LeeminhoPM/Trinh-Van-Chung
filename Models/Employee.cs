using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChungTrinhj.Models;

public partial class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = null!;

    [Required]
    public string Gender { get; set; } = null!;

    [Required]
    public string Phone { get; set; } = null!;

    [MaxLength(200)]
    public string? Email { get; set; }

    [Range(5000000, 100000000)]
    public double Salary { get; set; }

    [Required]
    public string Status { get; set; } = null!;

    public string imageUrl { get; set; }
}
