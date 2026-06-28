using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Core.DTOs;
using University.Data.Entities;
using University.Data.Repositories;

namespace University.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

         

        public async Task Delete(int id)
        {
            var student = await _repository.GetById(id);
            if (student == null)
                throw new Exception();

            await _repository.Delete(id);
        }

        public async Task<IEnumerable<StudentDto>> GetAll()
        { 
            var students=await _repository.GetAll();

            return students.Select(s => new StudentDto
            {
                Email = s.Email,
                Id = s.Id,
                Name = s.Name
            });
        }

        public async Task<StudentDto?> GetById(int id)
        { 
            var student =await _repository.GetById(id);

            if (student == null) return null;

            return new StudentDto
            {
                Email = student.Email,
                Id =student.Id ,
                Name=student.Name
            };

        }

        public async Task Update(int id, UpdateStudentForm form)
        {

            var student = await _repository.GetById(id);
            if (student == null) return;

            student.Email = form.Email;
            student.Name = form.Name;

              await _repository.Update(student);
        }

       public async Task<int> Create(CreateStudentForm form)
        {
            var student = new Student
            {
                Email = form.Email,
                Name = form.Name
            };


             await _repository.Add(student);

            return student.Id;
        }
    }
}
