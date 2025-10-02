using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChungTrinhj.Models;

public partial class Employee
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nhập tên đê")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "Chọn giới tính đê")]
    public string Gender { get; set; } = null!;

    [Required(ErrorMessage = "Nhập số điện thoại đê")]
    public string Phone { get; set; } = null!;

    [MaxLength(200, ErrorMessage = "Nhập ngắn thôi")]
    public string? Email { get; set; }

    [Range(5000000, 100000000, ErrorMessage = "Nhập trong khoảng 5tr đến 100tr")]
    public double Salary { get; set; }

    [Required(ErrorMessage = "Nhập status đê")]
    public string Status { get; set; } = null!;
    [ValidateNever]
    public string imageUrl { get; set; } = null!;
}
