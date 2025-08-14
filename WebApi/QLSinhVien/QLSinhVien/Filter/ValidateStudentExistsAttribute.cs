using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QLSinhVien.Services;

namespace QLSinhVien.Filters
{
    public class ValidateStudentExistsAttribute : ActionFilterAttribute
    {
        private readonly IStudentService _studentService;

        public ValidateStudentExistsAttribute(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            if (context.ActionArguments.ContainsKey("id"))
            {
                var id = (int)context.ActionArguments["id"];

                var student = await _studentService.GetByIdAsync(id);
                if (student == null)
                {
                    
                    context.Result = new NotFoundObjectResult(new
                    {
                        message = $"Không tìm thấy sinh viên với id = {id}"
                    });
                    return; 
                }
            }

            
            await next();
        }
    }
}
