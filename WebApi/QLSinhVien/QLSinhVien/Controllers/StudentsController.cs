using Microsoft.AspNetCore.Mvc;
using QLSinhVien.DTOs.Student;
using QLSinhVien.Models;
using QLSinhVien.Services;
using QLSinhVien.Filters;

namespace QLSinhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidateStudentExistsAttribute))]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(StudentCreateDto dto)
        {
            var student = await _studentService.CreateStudentAsync(dto);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidateStudentExistsAttribute))]
        public async Task<ActionResult<Student>> UpdateStudent(int id, StudentUpdateDto dto)
        {
            var updatedStudent = await _studentService.UpdateStudentAsync(id, dto);
            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateStudentExistsAttribute))]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}
