using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Core.DTOs;

namespace University.Core.Services
{
    public interface IStudentService
    {

        Task<IEnumerable<StudentDto>> GetAll();

        Task<int> Create(CreateStudentForm form);

         Task Update(int id, UpdateStudentForm form);
         Task Delete(int id);
        Task<StudentDto?> GetById(int id);
    }
}
