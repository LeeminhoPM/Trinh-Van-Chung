using System;
using System.Collections.Generic;

namespace ChungTrinhj.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public double Salary { get; set; }

    public string Status { get; set; } = null!;
}
