using System;
using System.Collections.Generic;

namespace Task2.API.Data.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Courser> Coursers { get; set; } = new List<Courser>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
