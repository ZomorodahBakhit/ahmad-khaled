using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace University.Data.Entities
{
    public class Student
    {
        public int Id { set; get; }

        public string Name { set; get; }=string.Empty;

        public string Email { set; get; }   =string.Empty;
    }
}
