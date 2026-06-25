using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task2.API.Data;
using Task2.API.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


var context = new UniversityContext();




var users = new List<User>
{
    new()
    {
        UserName = "AYA11",
        FirstName = "Aya",
        LastName = "Ali",
        EmailAddress = "AyaAli@gmail.com",
        PhoneNumber = "0957758155",
        Role = "Student"
    },

    new()
    {
        UserName = "FAW11",
        FirstName = "Fawzy",
        LastName = "Ahmed",
        EmailAddress = "FawzyAhmad@gmail.com",
        PhoneNumber = "0986401222",
        Role = "Student"
    },

    new()
    {
        UserName = "TsAM",
        FirstName = "Sami",
        LastName = "Hijazi",
        EmailAddress = "SamiHijazi@gmail.com",
        PhoneNumber = "0911122321",
        Role = "Teacher"
    }
};

context.Users.AddRange(users);
await context.SaveChangesAsync();


var courses = new List<Courser>
{
    new()
    {
        CourseName = "SQL",
        TeacherId = 13,
        StarteDate = new DateTime(2025,1,1),
        EndDate = new DateTime(2025,3,1),
        SyllabusId = 1
    },

    new()
    {
        CourseName = "C#",
        TeacherId = 13,
        StarteDate = new DateTime(2025,2,1),
        EndDate = new DateTime(2025,3,4),
        SyllabusId = 2
    }
};

context.Coursers.AddRange(courses);
await context.SaveChangesAsync();

var assignments = new List<Assignment>
{
    // SQL Course  
    new() { CourseId = 10, AssignmentTitle = "create a function", Description = "function to calculate the sum two numbers", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,12,4) },
    new() { CourseId = 10, AssignmentTitle = "create a function", Description = "function to calculate the division two numbers", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,10,4) },
    new() { CourseId = 10, AssignmentTitle = "create a function", Description = "function to calculate the sub two numbers", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,4,4) },
    new() { CourseId = 10, AssignmentTitle = "create a function", Description = "function to calculate the mul two numbers", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,5,4) },
    new() { CourseId = 10, AssignmentTitle = "create a function", Description = "function to calculate the sum two numbers", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,6,4) },

    // C#
    new() { CourseId = 13, AssignmentTitle = "create a Course model", Description = "Create a model for course", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,12,4) },
    new() { CourseId = 13, AssignmentTitle = "create a user model", Description = "Create a model for user", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,10,4) },
    new() { CourseId = 13, AssignmentTitle = "create an Assignment model", Description = "Create a model for assignment", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,4,4) },
    new() { CourseId = 13, AssignmentTitle = "create a Grade model", Description = "Create a model for grade", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,5,4) },
    new() { CourseId = 13, AssignmentTitle = "create a syllabus model", Description = "Create a model for syllabus", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,6,4) },

    // Entity Framework
    new() { CourseId = 14, AssignmentTitle = "create application layer", Description = "Create Application Layer", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,12,4) },
    new() { CourseId = 14, AssignmentTitle = "create API layer", Description = "Create API Layer", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,10,4) },
    new() { CourseId = 14, AssignmentTitle = "create Domain layer", Description = "Create Domain Layer", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,4,4) },
    new() { CourseId = 14, AssignmentTitle = "create Infrastructure layer", Description = "Create Infrastructure Layer", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,5,4) },
    new() { CourseId = 14, AssignmentTitle = "Download NuGet package", Description = "Download package", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,6,4) },

    // React
    new() { CourseId = 16, AssignmentTitle = "React Basics", Description = "Create a counter with increment button", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,7,1) },
    new() { CourseId = 16, AssignmentTitle = "Props and State", Description = "Build a counter with props for start", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,7,5) },
    new() { CourseId = 16, AssignmentTitle = "Event Handling", Description = "Add decrement and reset buttons", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,7,10) },
    new() { CourseId = 16, AssignmentTitle = "Styling Components", Description = "Style the counter using CSS Modules", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,7,15) },
    new() { CourseId = 16, AssignmentTitle = "Advanced Counter Logic", Description = "Implement double-click increment", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026,7,20) }
};

context.Assignments.AddRange(assignments);




var syllabuses = new List<Syllabus>
{
    new() { Description = "Introduction to SQL, querying, joins, subqueries, indexes, optimization" },
    new() { Description = "C# basics, OOP principles, LINQ, asynchronous programming" },
    new() { Description = "ORM concepts, DB context, migrations, querying with LINQ" },
    new() { Description = "RESTful API design, routing, controllers, authentication, versioning" },
    new() { Description = "Component-based UI, state management, hooks, lifecycle methods" }
};

context.Syllabi.AddRange(syllabuses);


var comments = new List<Comment>
{
    new() { AssignmentId = 21, CreatedeByUserId = 2, CreatedDate = new DateTime(2026,6,20), CommentContent = "Counter increments smoothly." },
    new() { AssignmentId = 21, CreatedeByUserId = 4, CreatedDate = new DateTime(2026,6,21), CommentContent= "Add button debounce to prevent rapid clicks." },
    new() { AssignmentId = 22, CreatedeByUserId= 5, CreatedDate= new DateTime(2026,7,1), CommentContent = "Props passed correctly, good job." },
    new() { AssignmentId = 22, CreatedeByUserId= 6, CreatedDate= new DateTime(2026,7,2), CommentContent = "Consider default prop values for robustness." },
    new() { AssignmentId = 23, CreatedeByUserId= 7, CreatedDate= new DateTime(2026,7,6), CommentContent = "Event handlers for decrement and reset work well." },
    new() { AssignmentId = 23, CreatedeByUserId= 8, CreatedDate= new DateTime(2026,7,7), CommentContent = "Add confirmation before reset." },
    new() { AssignmentId = 24, CreatedeByUserId= 8, CreatedDate= new DateTime(2026,7,10), CommentContent = "CSS modules scoped correctly, styling looks clean." },
    new() { AssignmentId = 2, CreatedeByUserId= 10, CreatedDate= new DateTime(2026,1,1), CommentContent = "Design schema meets requirements." },
    new() { AssignmentId = 3, CreatedeByUserId= 9, CreatedDate = new DateTime(2026,1,2), CommentContent = "Table creation script executed without errors." },
    new() { AssignmentId = 15, CreatedeByUserId = 12, CreatedDate = new DateTime(2026,6,3), CommentContent = "Syllabus model structure looks solid." } 
     
};

context.Comments.AddRange(comments);

 
var grades = new List<Grade>
{
    new() { AssignmentId = 2, StudentId = 1, Grade1= 85 },
    new() { AssignmentId = 3, StudentId = 1, Grade1= 72 },
    new() { AssignmentId = 5, StudentId = 1, Grade1= 91 },
    new() { AssignmentId = 6, StudentId = 1, Grade1= 68 },
    new() { AssignmentId = 7, StudentId = 1, Grade1= 80 },
    new() { AssignmentId = 8, StudentId = 1, Grade1= 75 },
    new() { AssignmentId = 9, StudentId =  1, Grade1= 95 },
    new() { AssignmentId = 10, StudentId = 1, Grade1= 62 },
    new() { AssignmentId = 11, StudentId = 1, Grade1= 88 },
    new() { AssignmentId = 12, StudentId = 1, Grade1= 79 },
    new() { AssignmentId = 13, StudentId = 1, Grade1= 93 },
    new() { AssignmentId = 14, StudentId = 1, Grade1= 70 },
    new() { AssignmentId = 15, StudentId = 1, Grade1= 81 },
    new() { AssignmentId = 16, StudentId = 1, Grade1= 65 },
    new() { AssignmentId = 17, StudentId = 1, Grade1= 84 },
    new() { AssignmentId = 18, StudentId = 1, Grade1= 77 },
    new() { AssignmentId = 19, StudentId = 1, Grade1= 90 },
    new() { AssignmentId = 20, StudentId = 1, Grade1= 60 },
    new() { AssignmentId = 21, StudentId = 1, Grade1= 82 },
    new() { AssignmentId = 22, StudentId = 1, Grade1= 73 },
    new() { AssignmentId = 23, StudentId = 1, Grade1= 94 },
    new() { AssignmentId = 24, StudentId = 1, Grade1= 66 },
    new() { AssignmentId = 25, StudentId = 1, Grade1 = 89 },
    new() { AssignmentId = 26, StudentId = 1, Grade1 = 71 },
    new() { AssignmentId = 27, StudentId = 1, Grade1 = 96 }
};

context.Grades.AddRange(grades);



var grades2 = new List<Grade>
{
    new() { AssignmentId = 2,  StudentId = 2, Grade1= 85 },
    new() { AssignmentId = 3,  StudentId = 2, Grade1= 72 },
    new() { AssignmentId = 5,  StudentId = 2, Grade1= 91 },
    new() { AssignmentId = 6,  StudentId = 2, Grade1= 68 },
    new() { AssignmentId = 7,  StudentId = 2, Grade1= 80 },
    new() { AssignmentId = 8,  StudentId = 2, Grade1= 75 },
    new() { AssignmentId = 9,  StudentId = 2, Grade1= 95 },
    new() { AssignmentId = 10, StudentId = 2, Grade1= 62 },
    new() { AssignmentId = 11, StudentId = 2, Grade1= 88 },
    new() { AssignmentId = 12, StudentId = 2, Grade1= 79 },
    new() { AssignmentId = 13, StudentId = 2, Grade1= 93 },
    new() { AssignmentId = 14, StudentId = 2, Grade1= 70 },
    new() { AssignmentId = 15, StudentId = 2, Grade1= 81 },
    new() { AssignmentId = 16, StudentId = 2, Grade1= 65 },
    new() { AssignmentId = 17, StudentId = 2, Grade1= 84 },
    new() { AssignmentId = 18, StudentId = 2, Grade1= 77 },
    new() { AssignmentId = 19, StudentId = 2, Grade1= 90 },
    new() { AssignmentId = 20, StudentId = 2, Grade1= 60 },
    new() { AssignmentId = 21, StudentId = 2, Grade1= 82 },
    new() { AssignmentId = 22, StudentId = 2, Grade1= 73 },
    new() { AssignmentId = 23, StudentId = 2, Grade1= 94 },
    new() { AssignmentId = 24, StudentId = 2, Grade1= 66 },
    new() { AssignmentId = 25, StudentId = 2, Grade1 = 89 },
    new() { AssignmentId = 26, StudentId = 2, Grade1 = 71 },
    new() { AssignmentId = 27, StudentId = 2, Grade1 = 96 }
};

context.Grades.AddRange(grades);


var grades3 = new List<Grade>
{
    new() { AssignmentId = 2,  StudentId = 3, Grade1= 85 },
    new() { AssignmentId = 3,  StudentId = 3, Grade1= 72 },
    new() { AssignmentId = 5,  StudentId = 3, Grade1= 91 },
    new() { AssignmentId = 6,  StudentId = 3, Grade1= 68 },
    new() { AssignmentId = 7,  StudentId = 3, Grade1= 80 },
    new() { AssignmentId = 8,  StudentId = 3, Grade1= 75 },
    new() { AssignmentId = 9,  StudentId = 3, Grade1= 95 },
    new() { AssignmentId = 10, StudentId = 3, Grade1= 62 },
    new() { AssignmentId = 11, StudentId = 3, Grade1= 88 },
    new() { AssignmentId = 12, StudentId = 3, Grade1= 79 },
    new() { AssignmentId = 13, StudentId = 3, Grade1= 93 },
    new() { AssignmentId = 14, StudentId = 3, Grade1= 70 },
    new() { AssignmentId = 15, StudentId = 3, Grade1= 81 },
    new() { AssignmentId = 16, StudentId = 3, Grade1= 65 },
    new() { AssignmentId = 17, StudentId = 3, Grade1= 84 },
    new() { AssignmentId = 18, StudentId = 3, Grade1= 77 },
    new() { AssignmentId = 19, StudentId = 3, Grade1= 90 },
    new() { AssignmentId = 20, StudentId = 3, Grade1= 60 },
    new() { AssignmentId = 21, StudentId = 3, Grade1= 82 },
    new() { AssignmentId = 22, StudentId = 3, Grade1= 73 },
    new() { AssignmentId = 23, StudentId = 3, Grade1= 94 },
    new() { AssignmentId = 24, StudentId = 3, Grade1= 66 },
    new() { AssignmentId = 25, StudentId = 3, Grade1 = 89 },
    new() { AssignmentId = 26, StudentId = 3, Grade1 = 71 },
    new() { AssignmentId = 27, StudentId = 3, Grade1 = 96 }
};

context.Grades.AddRange(grades);









//List all courses

var courses1= await context.Coursers.ToListAsync();

//show all assignments for a specific course

var assignments2 = await context.Assignments
    .Where(a => a.CourseId == 6)
    .ToListAsync();

//List all students

var students = await context.Users
    .Where(u => u.Role == "student")
    .ToListAsync();

//Show all comments for a given assignment

var comments1 = await context.Comments
    .Where(c => c.AssignmentId == 21)
    .ToListAsync();

//Show all grades for a student

var grade = await context.Grades
    .Where(g => g.StudentId == 2)
    .ToListAsync();


//List each assignment with its course and the teacher’s full name

var result = await context.Assignments
    .Select(a => new
    {
        Assignment = a.AssignmentTitle,
        Course = a.Course.CourseName,
        Teacher = a.Course.Teacher.FirstName + " " +
                  a.Course.Teacher.LastName
    })
    .ToListAsync();



//Query to show average grade per course

var averages = await context.Grades
    .GroupBy(g => g.Assignment.CourseId)
    .Select(g => new
    {
         
        CourseId = g.Key,
        AverageGrade = g.Average(x => x.Grade1)
    })
    .ToListAsync();



 
//Update a student’s role to “Teacher”

var student = await context.Users
    .FirstOrDefaultAsync(u => u.UserId == 2);

if (student != null)
{
    student.Role = "Teacher";
    await context.SaveChangesAsync();
}



//Delete a specific comment

var comment = await context.Comments
    .FirstOrDefaultAsync(c => c.CommentId == 10);

if (comment != null)
{
    context.Comments.Remove(comment);
    await context.SaveChangesAsync();
}




//Create a method to return letter grades (A, B, C, etc.) based on the student’s performance

  async Task<string> GetStudentGradeAsync(
    int studentId,
    int courseId)
{
    var finalGrade = await context.Grades
        .Where(g =>
            g.StudentId == studentId &&
            g.Assignment.CourseId == courseId)
        .SumAsync(g =>
            (g.Grade1 * 100.0 / g.Assignment.MaxGrade)
            * g.Assignment.Weight / 100.0);

    return finalGrade switch
    {
        >= 90 => "A",
        >= 80 => "B",
        >= 70 => "C",
        >= 60 => "D",
        _ => "F"
    };
}

//Create a method to calculate GPA for a student


async Task<double> GetStudentGpaAsync(int studentId)
{
    var grades = await context.Grades
        .Where(g => g.StudentId == studentId)
        .Select(g => g.Grade1)
        .ToListAsync();

    if (!grades.Any())
        return 0;

    var averageGrade = grades.Average() ?? 0;

    return Math.Round(
        averageGrade / 100.0 * 4.0,
        2);
}