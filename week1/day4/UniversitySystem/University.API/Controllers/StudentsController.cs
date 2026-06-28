using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using University.Core.DTOs;
using University.Core.Iservices;

namespace University.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService studentService)
        {
            _service = studentService;
        }

        [HttpGet]
        public async Task<ApiResponse> GetAll()
        {
            var students = await _service.GetAll();
            return new ApiResponse("Students retrieved successfully.", students, 200);
        }


        [HttpGet("{id}")]
        public async Task<ApiResponse> GetById(int id)
        {

            var student = await _service.GetById(id);
            return new ApiResponse($"Student with ID {id} retrieved successfully.", student, 200);

        }

        [HttpPost]
        public async Task<ApiResponse> Create([FromBody] CreateStudentForm form)
        {

            if (form == null)
                throw new ApiException("Invalid student data.", 400);


            var studentId = await _service.Create(form);
            return new ApiResponse($"Student created successfully with ID: {studentId}.", studentId, 201);
        }

        [HttpPut("{id}")]
        public async Task<ApiResponse> Update(int id, [FromBody] UpdateStudentForm form)
        {

            if (form == null)
                throw new ApiException("Invalid update data.", 400);



            await _service.Update(id, form); // ✅ استخدام await
            return new ApiResponse($"Student with ID {id} updated successfully.", null, 200);

        }


        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(int id)
        {

            await _service.Delete(id);
            return new ApiResponse($"Student with ID {id} deleted successfully.", null, 200);
        }
    }
}