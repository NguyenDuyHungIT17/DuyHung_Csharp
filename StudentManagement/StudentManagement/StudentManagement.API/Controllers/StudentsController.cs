using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Bussiness.Interfaces;
using StudentManagement.Shared.DTOs.Student;
using System.Threading.Tasks;

namespace StudentManagement.API.Controllers
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
        public ActionResult<IEnumerable<StudentDto>> GetAll()
        {
            var students = _studentService.GetAll();
            return Ok(students);
        }

      
        [HttpGet("{id}")]
        public ActionResult<StudentDto> GetById(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null)
                return NotFound(new { message = $"Student with ID {id} not found." });

            return Ok(student);
        }

        
        [HttpPost]
        public async Task<ActionResult<StudentDto>> Create(StudentCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

             _studentService.Add(dto);

            return Ok(dto);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingStudent = _studentService.GetById(id);
            if (existingStudent == null)
                return NotFound(new { message = $"Student with ID {id} not found." });

            _studentService.Update(id, dto);
            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingStudent = _studentService.GetById(id);
            if (existingStudent == null)
                return NotFound(new { message = $"Student with ID {id} not found." });

            _studentService.Delete(id);
            return NoContent();
        }
    }
}
