using Microsoft.EntityFrameworkCore;
using StudentManagement.Bussiness.Interfaces;
using StudentManagement.Data.Context;
using StudentManagement.Data.Entities;
using StudentManagement.Shared.DTOs.Student;

namespace StudentManagement.Business.Services
{
    public class StudentService : IStudentService
    {
        private readonly SMDbContext _context;

        public StudentService(SMDbContext context)
        {
            _context = context;
        }

        public IEnumerable<StudentDto> GetAll()
        {
            return _context.Students
                .Select(s => new StudentDto
                {
                    StudentId = s.StudentId,
                    FullName = s.FullName,
                    DateOfBirth = s.DateOfBirth,
                    Email = s.Email,
                    GPA = s.Gpa,
                })
                .ToList();
        }

        public StudentDto? GetById(int id)
        {
            return _context.Students
                .Where(s => s.StudentId == id)
                .Select(s => new StudentDto
                {
                    StudentId = s.StudentId,
                    FullName = s.FullName,
                    DateOfBirth = s.DateOfBirth,
                    GPA = s.Gpa
                })
                .FirstOrDefault();
        }

        public void Add(StudentCreateDto studentCreateDto)
        {
            var student = new Student
            {
                FullName = studentCreateDto.FullName,
                DateOfBirth = studentCreateDto.DateOfBirth,
                Gpa = studentCreateDto.GPA,
                Email = studentCreateDto.Email,
                
            };

            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(int id, StudentUpdateDto studentUpdateDto)
        {
            var existingStudent = _context.Students.Find(id);
            if (existingStudent == null)
                throw new KeyNotFoundException($"Student with ID {id} not found.");

            existingStudent.FullName = studentUpdateDto.FullName;
            existingStudent.DateOfBirth = studentUpdateDto.DateOfBirth;
            existingStudent.Gpa = studentUpdateDto.GPA;

            _context.Entry(existingStudent).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                throw new KeyNotFoundException($"Student with ID {id} not found.");

            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}
