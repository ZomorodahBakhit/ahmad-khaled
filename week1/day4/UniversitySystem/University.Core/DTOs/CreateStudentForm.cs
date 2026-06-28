using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Core.DTOs
{
    public record CreateStudentForm
    {
        [Required]
        public string Name { get; init; } = string.Empty;

        [Required]
        public string Email { get; init; } = string.Empty;
    }
}
