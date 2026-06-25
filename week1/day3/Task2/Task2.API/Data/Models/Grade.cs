using System;
using System.Collections.Generic;

namespace Task2.API.Data.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int AssignmentId { get; set; }

    public int StudentId { get; set; }

    public int? Grade1 { get; set; }

    public virtual Assignment Assignment { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
