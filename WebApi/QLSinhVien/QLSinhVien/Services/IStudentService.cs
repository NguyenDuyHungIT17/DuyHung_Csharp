using QLSinhVien.DTOs.Student;
using QLSinhVien.Models;

namespace QLSinhVien.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync(CancellationToken ct = default);
        Task<Student> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Student> CreateStudentAsync(StudentCreateDto studentCreateDto, CancellationToken ct = default);
        Task<Student> UpdateStudentAsync(int id, StudentUpdateDto studentUpdateDto,  CancellationToken ct = default);    
        Task<bool> DeleteStudentAsync(int id, CancellationToken ct = default);
    }
}
