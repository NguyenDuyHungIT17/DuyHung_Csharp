using Microsoft.EntityFrameworkCore;
using QLSinhVien.DTOs.Student;
using QLSinhVien.Models;

namespace QLSinhVien.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student?> CreateStudentAsync(StudentCreateDto dto, CancellationToken ct = default)
        {
            if (dto.NgaySinh.HasValue && dto.NgaySinh.Value.Date > DateTime.UtcNow.Date)
            {
                return null;
            }

            var student = new Student
            {
                HoTen = dto.HoTen,
                NgaySinh = dto.NgaySinh,
                DiemTb = dto.DiemTB
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync(ct);

            return student;
        }

        public async Task<bool> DeleteStudentAsync(int id, CancellationToken ct = default)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id, ct);
            if (student == null)
                return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(ct);

            return true;
        }

        public async Task<List<Student>> GetAllAsync(CancellationToken ct = default)
        {
            var students = await _context.Students.AsNoTracking().ToListAsync(ct);

            return students;
        }

        public async Task<Student?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            if (id <= 0)
                return null;

            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == id, ct);

            return student;
        }

        public async Task<Student?> UpdateStudentAsync(int id, StudentUpdateDto dto, CancellationToken ct = default)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id, ct);
            if (student == null)
                return null;

            if (dto.NgaySinh.HasValue && dto.NgaySinh.Value.Date > DateTime.UtcNow.Date)
                return null;

            student.HoTen = dto.HoTen;
            student.NgaySinh = dto.NgaySinh;
            student.DiemTb = dto.DiemTB;

            await _context.SaveChangesAsync(ct);

            return student;
        }
    }
}
