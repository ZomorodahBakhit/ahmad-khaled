using Microsoft.EntityFrameworkCore;
using System;
using University.Data.Context;
using University.Data.Entities;
using University.Data.IRepositories;

namespace University.Data.Repositories
{
    public class StudentRepository : IStudentRepository
        {
            private readonly AppDbContext _context;

            public StudentRepository(AppDbContext context)
            {
                _context = context;
            }

         

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

      public  async Task   Add(Student student)
        {

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

       public async Task   Update(Student student)
        {
             _context.Students.Update(student);

          await  _context.SaveChangesAsync();
        }

       public async Task Delete(int id)
        { 
            var student= await GetById(id);

            if(student !=null)
            {
                _context.Students.Remove(student);
                 await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Student not found");
            }
        }

        public Task<Student> GetById(int id)
        { 
            return _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

     
    }
    }
 
