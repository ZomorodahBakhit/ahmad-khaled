using System;
using System.Collections.Generic;

namespace Task2.API.Data.Models;

public partial class Assignment
{
    public int AssignmentId { get; set; }

    public int CourseId { get; set; }

    public string AssignmentTitle { get; set; } = null!;

    public string? Description { get; set; }

    public double Weight { get; set; }

    public int MaxGrade { get; set; }

    public DateOnly DueDate { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Courser Course { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
