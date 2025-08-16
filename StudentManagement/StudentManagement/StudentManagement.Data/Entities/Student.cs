using System;
using System.Collections.Generic;

namespace StudentManagement.Data.Entities;

public partial class Student
{
    public int StudentId { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public decimal? Gpa { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
