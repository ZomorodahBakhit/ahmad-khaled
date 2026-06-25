using System;
using System.Collections.Generic;

namespace Task2.API.Data.Models;

public partial class Syllabus
{
    public int SyllabusId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Courser> Coursers { get; set; } = new List<Courser>();
}
