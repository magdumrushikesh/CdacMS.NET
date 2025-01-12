using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DbFirst.Models;

public partial class Department
{
    [Key]
    [Column("DeptNo", TypeName = "int")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int DeptNo { get; set; }


    [Column("DeptName", TypeName = "varchar(50)")]
    public string DeptName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
