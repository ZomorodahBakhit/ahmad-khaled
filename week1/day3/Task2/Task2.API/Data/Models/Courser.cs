using System;
using System.Collections.Generic;

namespace Task2.API.Data.Models;

public partial class Courser
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public int? TeacherId { get; set; }

    public DateTime StarteDate { get; set; }

    public DateTime EndDate { get; set; }

    public int? SyllabusId { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual Syllabus? Syllabus { get; set; }

    public virtual User? Teacher { get; set; }
}
