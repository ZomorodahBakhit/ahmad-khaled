using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data.Entities;

namespace University.Data.Context
{
    public class AppDbContext : DbContext
    {


        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options  )
        {
            
        }

        public DbSet<Student> Students { set; get; }




    }
}
