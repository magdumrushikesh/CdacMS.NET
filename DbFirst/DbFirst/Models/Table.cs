using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class Table
{
    public int EmpNo { get; set; }

    public string? Name { get; set; }

    public decimal? Basic { get; set; }

    public int? DeptNo { get; set; }
}
