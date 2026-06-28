using University.Data.Entities;

namespace University.Data.IRepositories
{
    public interface IStudentRepository
    {


        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);

        Task Add(Student student);

        Task Update(Student student);

        Task Delete(int id);

    }
}
