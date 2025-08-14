using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QLSinhVien.Models;

public partial class Student
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string HoTen { get; set; } = null!;

    public DateTime? NgaySinh { get; set; }

    [Column("DiemTB")]
    public double? DiemTb { get; set; }
}
