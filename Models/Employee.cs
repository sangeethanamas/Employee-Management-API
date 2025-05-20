using System;
using System.Collections.Generic;

namespace Employee_Management_API.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Department { get; set; }

    public decimal? Salary { get; set; }

    public string? City { get; set; }
}
