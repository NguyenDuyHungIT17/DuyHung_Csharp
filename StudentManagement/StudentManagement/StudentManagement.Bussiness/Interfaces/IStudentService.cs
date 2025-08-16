using StudentManagement.Shared.DTOs.Student;
using System.Collections.Generic;

namespace StudentManagement.Bussiness.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentDto> GetAll();
        StudentDto? GetById(int id);
        void Add(StudentCreateDto studentCreateDto);
        void Update(int id, StudentUpdateDto studentUpdateDto);
        void Delete(int id);
    }
}
