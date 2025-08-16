using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Shared.DTOs.Student
{
    public class StudentUpdateDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(0, 4)]
        public decimal? GPA { get; set; }
    }
}
