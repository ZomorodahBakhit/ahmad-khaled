


--Create a database named University.

use Master ;

create Database University


GO
USE [University]

GO


--Create Table :


/****** Object:  Table [dbo].[Assignments]    Script Date: 6/23/2026 2:52:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Assignments](
	[AssignmentId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[AssignmentTitle] [varchar](128) NOT NULL,
	[Description] [text] NULL,
	[Weight] [float] NOT NULL,
	[MaxGrade] [int] NOT NULL,
	[DueDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Coursers] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Coursers] ([CourseID])
GO

ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignments_Coursers]
GO

USE [University]
GO

/****** Object:  Table [dbo].[Comments]    Script Date: 6/23/2026 2:52:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Comments](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[AssignmentId] [int] NOT NULL,
	[CreatedeByUserId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CommentContent] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Comments]  WITH CHECK ADD FOREIGN KEY([AssignmentId])
REFERENCES [dbo].[Assignments] ([AssignmentId])
GO

ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK__Comments__Create__4222D4EF] FOREIGN KEY([CreatedeByUserId])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK__Comments__Create__4222D4EF]
GO

ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Assignments] FOREIGN KEY([AssignmentId])
REFERENCES [dbo].[Assignments] ([AssignmentId])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Assignments]
GO

USE [University]
GO

/****** Object:  Table [dbo].[Coursers]    Script Date: 6/23/2026 2:53:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Coursers](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](100) NOT NULL,
	[TeacherId] [int] NULL,
	[StarteDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[SyllabusId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Coursers]  WITH CHECK ADD  CONSTRAINT [FK_Coursers_Syllabus] FOREIGN KEY([SyllabusId])
REFERENCES [dbo].[Syllabus] ([SyllabusId])
GO

ALTER TABLE [dbo].[Coursers] CHECK CONSTRAINT [FK_Coursers_Syllabus]
GO

ALTER TABLE [dbo].[Coursers]  WITH CHECK ADD  CONSTRAINT [FK_Coursers_Users] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[Coursers] CHECK CONSTRAINT [FK_Coursers_Users]
GO



USE [University]
GO

/****** Object:  Table [dbo].[Grades]    Script Date: 6/23/2026 2:53:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Grades](
	[GradeId] [int] IDENTITY(1,1) NOT NULL,
	[AssignmentId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Grade] [int] NULL,
 CONSTRAINT [PK__Grades__54F87A5783E53AE4] PRIMARY KEY CLUSTERED 
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Assignments] FOREIGN KEY([AssignmentId])
REFERENCES [dbo].[Assignments] ([AssignmentId])
GO

ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Assignments]
GO

ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Users] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Users]
GO
USE [University]
GO

/****** Object:  Table [dbo].[Syllabus]    Script Date: 6/23/2026 2:53:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Syllabus](
	[SyllabusId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK__Syllabus__9B8016A6BC42B6D4] PRIMARY KEY CLUSTERED 
(
	[SyllabusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


USE [University]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 6/23/2026 2:53:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](64) NOT NULL,
	[FirstName] [varchar](64) NOT NULL,
	[LastName] [varchar](64) NOT NULL,
	[EmailAddress] [varchar](128) NOT NULL,
	[PhoneNumber] [varchar](16) NOT NULL,
	[Role] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [EmailAddress_Users_unique] UNIQUE NONCLUSTERED 
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK_Users] CHECK  ((len([PhoneNumber])=(10)))
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK_Users]
GO



--Write SQL statements to INSERT data for all the interns into the user table with Role  Student 

 GO
 insert into Users
 Values 
-- ('AYM11','Ayman','Durra','AymanDurra@gmail.com','0986401252','student'),
 --('AHM11','Ahmad','Khaled','Ahmadkhaled@gmail.com','0945677165','student'),
 ('AYA11','Aya','Ali','AyaAli@gmail.com','0957758155','student'),
 ('FAW11','Fawzy','Ahmed','FawzyAhmad@gmail.com','0986401222','student'),
 ('HIB11','Hiba','kossa','HibaKossa@gmail.com','0987785196','student'),
 ('MAS11','Massa','Basr','MassaNasr@gmail.com','0955548132','student'),
 ('MEH11','Mehyar','khuder','MehyarKhuder@gmail.com','0974485987','student'),
 ('MOT11','Motaz','ALmasri','MotazALmasri@gmail.com','0958865498','student'),
 ('MOU11','Mouaz','Zakaria','MouazZakaria@gmail.com','0925523654','student'),
 ('YEH11','Yehya','Msouty','YehyaMsouty@gmail.com','0911121222','student')
 


 --Write SQL statements to INSERT data for Sami, Feryal into the user table with Role  Teacher 
 GO
 insert into Users
 Values 
 ('TsAM','Sami','Hijazi','SamiHijazi@gmail.com','0911122321','Teacher'),
 ('Tferyal','Feryal','Ali','FeryalAli@gmail.com','0911155151','Teacher')

 Go

 USE [University]
GO
 

 --Write SQL statements to INSERT data for SQL, C#, Entity Framework, Web API and React Courses.
 GO
 insert into Coursers
VALUES
('SQL', 13, '2025-01-01', '2025-03-01', 1),
('C#', 13, '2025-02-01', '2025-03-04', 2),
('Entity FrameWork', 13, '2026-01-04', '2026-05-01', 3),
('Web Api', 14, '2026-04-05', '2026-05-04', 4),
('React', 14, '2026-07-01', '2026-09-01', 5);
GO



 --Write SQL Statements to INSERT at least 5 Assignments for each Course with random due dates (past & future)
    

   insert into Assignments
   values	
   (10,'craete a funciton','funciton to calculate the sum tow nunber',20,100,'2026-12-4'),
   
   (10,'craete a funciton','funciton to calculate the division tow nunber',20,100,'2026-10-4'),
   
   (10,'craete a funciton','funciton to calculate the Sub tow nunber',20,100,'2026-4-4'),
   (10,'craete a funciton','funciton to calculate the Mul tow nunber',20,100,'2026-5-4'),	
   (10,'craete a funciton','funciton to calculate the sum tow nunber',20,100,'2026-6-4')
   GO

   




   insert into Assignments
   values	
   (13,'create a Course model','Create to a model for course',20,100,'2026-12-4'),
   
   (13,'create a user model','Create to a model for user',20,100,'2026-10-4'),
   
   (13,'create a Assignment model','Create to a model for assignment',20,100,'2026-4-4'),
   (13,'create a Grade model','Create to a model for grade',20,100,'2026-5-4'),	
   (13,'create a syllabuse mode','Create to a model for syllabus',20,100,'2026-6-4')


   Go

   insert into Assignments
   values	
   (14,'create a application layer','create an Application',20,100,'2026-12-4'),
   (14,'create a Api layer','create an Api',20,100,'2026-10-4'),
   (14,'create a Domain layer','create an Domain',20,100,'2026-4-4'),
   (14,'create a  infrastucutre','create an infrastucture',20,100,'2026-5-4'),	
   (14,'Donwload nuGet package','Download package ',20,100,'2026-6-4')

   Go

   
insert into assignments 
VALUES
(16,'React Basics', 'Create a counter with increment button', 20, 100, '2026-07-01'),
(16,'Props and State', 'Build a counter with props for start', 20, 100, '2026-07-05'),
(16,'Event Handling', 'Add decrement and reset buttons', 20, 100, '2026-07-10'),
(16,'Styling Components', 'Style the counter using CSS Modules', 20, 100, '2026-07-15'),
(16,'Advanced Counter Logic', 'Implement double-click increment', 20, 100, '2026-07-20');

 


GO

--Write SQL Statement to INSERT Syllabus for each Course.

INSERT INTO Syllabus 
VALUES
('Introduction to SQL, querying, joins, subqueries, indexes, optimization'),
('C# basics, OOP principles, LINQ, asynchronous programming'),
('ORM concepts, DB context, migrations, querying with LINQ'),
('RESTful API design, routing, controllers, authentication, versioning'),
('Component-based UI, state management, hooks, lifecycle methods');



GO

 --Write SQL Statements to INSERT at least 10 comments for random assignments.

insert into Comments 
VALUES
(21,2, '2026-06-20', 'Counter increments smoothly.'),
(21,4, '2026-06-21', 'Add button debounce to prevent rapid clicks.'),
(22,5, '2026-07-01', 'Props passed correctly, good job.'),
(22,6, '2026-07-02', 'Consider default prop values for robustness.'),
(23,7, '2026-07-06', 'Event handlers for decrement and reset work well.'),
(23,8, '2026-07-07', 'Add confirmation before reset.'),
(24,8, '2026-07-10', 'CSS modules scoped correctly, styling looks clean.'),
(2,10, '2026-01-01', 'Design schema meets requirements.'),
(3,9, '2026-01-02', 'Table creation script executed without errors.'),
(15,12, '2026-06-03', 'Syllabus model structure looks solid.');



GO

--Write SQL Statement to INSERT random grades for all students for every assignment.
 


 GO
 -- StudentId: 2
INSERT INTO Grades  
VALUES 
(2, 2, 85),
 (3, 2, 72),
 (5, 2, 91),
 (6, 2, 68),
 (7, 2, 80),
 (8, 2, 75),
 (9, 2, 95),
 (10, 2, 62),
 (11, 2, 88),
 (12, 2, 79),
 (13, 2, 93),
 (14, 2, 70),
 (15, 2, 81),
 (16, 2, 65),
 (17, 2, 84),
 (18, 2, 77),
 (19, 2, 90),
 (20, 2, 60),
 (21, 2, 82),
 (22, 2, 73),
 (23, 2, 94),
 (24, 2, 66),
 (25, 2, 89),
 (26, 2, 71),
 (27, 2, 96)
			  
 
INSERT INTO Grades 
VALUES
(2, 4, 78),
 (3, 4, 90),
 (5, 4, 65),
 (6, 4, 82),
 (7, 4, 70),
 (8, 4, 94),
 (9, 4, 61),
 (10, 4, 88),
 (11, 4, 75),
 (12, 4, 92),
 (13, 4, 69),
 (14, 4, 80),
 (15, 4, 73),
 (16, 4, 96),
 (17, 4, 63),
 (18, 4, 85),
 (19, 4, 76),
 (20, 4, 99),
 (21, 4, 67),
 (22, 4, 81),
 (23, 4, 74),
 (24, 4, 97),
 (25, 4, 62),
 (26, 4, 86),
 (27, 4, 77) 
			
		--Student=5
INSERT INTO Grades   
VALUES 
(2, 5, 92),
 (3, 5, 70),
 (5, 5, 88),
 (6, 5, 63),
 (7, 5, 81),
 (8, 5, 74),
 (9, 5, 95),
 (10, 5, 66),
 (11, 5, 89),
 (12, 5, 71),
 (13, 5, 93),
 (14, 5, 60),
 (15, 5, 87),
 (16, 5, 78),
 (17, 5, 90),
 (18, 5, 69),
 (19, 5, 83),
 (20, 5, 72),
 (21, 5, 98),
 (22, 5, 64),
 (23, 5, 84),
 (24, 5, 76),
 (25, 5, 91),
 (26, 5, 67),
 (27, 5, 80);
		 
-- --Student=6 
INSERT INTO Grades  
VALUES
(2, 6, 75),
 (3, 6, 89),
 (5, 6, 62),
 (6, 6, 91),
 (7, 6, 70),
 (8, 6, 84),
 (9, 6, 65),
 (10, 6, 93),
 (11, 6, 73),
 (12, 6, 80),
 (13, 6, 60),
 (14, 6, 95),
 (15, 6, 77),
 (16, 6, 86),
 (17, 6, 68),
 (18, 6, 90),
 (19, 6, 71),
 (20, 6, 82),
 (21, 6, 64),
 (22, 6, 94),
 (23, 6, 79),
 (24, 6, 87),
 (25, 6, 61),
 (26, 6, 96),
 (27, 6, 72);
		 
		  
-- --Student=7 
INSERT INTO Grades  
VALUES 
(2, 7, 88),
 (3, 7, 60),
 (5, 7, 95),
 (6, 7, 72),
 (7, 7, 85),
 (8, 7, 65),
 (9, 7, 90),
 (10, 7, 78),
 (11, 7, 93),
 (12, 7, 68),
 (13, 7, 81),
 (14, 7, 70),
 (15, 7, 96),
 (16, 7, 63),
 (17, 7, 84),
 (18, 7, 76),
 (19, 7, 99),
 (20, 7, 67),
 (21, 7, 82),
 (22, 7, 74),
 (23, 7, 97),
 (24, 7, 62),
 (25, 7, 86),
 (26, 7, 77),
 (27, 7, 91)
			 
-- --Student=8 
INSERT INTO Grades  
VALUES
(2, 8, 70),
 (3, 8, 92),
 (5, 8, 68),
 (6, 8, 85),
 (7, 8, 79),
 (8, 8, 91),
 (9, 8, 62),
 (10, 8, 88),
 (11, 8, 75),
 (12, 8, 94),
 (13, 8, 60),
 (14, 8, 80),
 (15, 8, 73),
 (16, 8, 96),
 (17, 8, 65),
 (18, 8, 84),
 (19, 8, 77),
 (20, 8, 90),
 (21, 8, 61),
 (22, 8, 82),
 (23, 8, 74),
 (24, 8, 97),
 (25, 8, 66),
 (26, 8, 89),
 (27, 8, 71);
		 
--Student=9 
INSERT INTO Grades
VALUES 
(2, 9, 81),
 (3, 9, 65),
 (5, 9, 90),
 (6, 9, 73),
 (7, 9, 88),
 (8, 9, 60),
 (9, 9, 95),
 (10, 9, 70),
 (11, 9, 83),
 (12, 9, 68),
 (13, 9, 92),
 (14, 9, 76),
 (15, 9, 85),
 (16, 9, 61),
 (17, 9, 94),
 (18, 9, 79),
 (19, 9, 87),
 (20, 9, 64),
 (21, 9, 91),
 (22, 9, 72),
 (23, 9, 80),
 (24, 9, 69),
 (25, 9, 96),
 (26, 9, 77),
 (27, 9, 84);
			  
--Student=10 
INSERT INTO Grades   
VALUES (2, 10, 74),
  (3, 10, 80),
  (5, 10, 60),
  (6, 10, 95),
  (7, 10, 71),
  (8, 10, 86),
  (9, 10, 66),
 (10, 10, 90),
 (11, 10, 78),
 (12, 10, 93),
 (13, 10, 63),
 (14, 10, 81),
 (15, 10, 72),
 (16, 10, 97),
 (17, 10, 69),
 (18, 10, 84),
 (19, 10, 75),
 (20, 10, 98),
 (21, 10, 62),
 (22, 10, 89),
 (23, 10, 77),
 (24, 10, 91),
 (25, 10, 67),
 (26, 10, 85),
 (27, 10, 70);
		 
 
-- StudentId =11
INSERT INTO Grades  
VALUES 
	(2, 11, 90),
  (3, 11, 77),
  (5, 11, 85),
  (6, 11, 62),
  (7, 11, 93),
  (8, 11, 70),
  (9, 11, 88),
 (10, 11, 65),
 (11, 11, 91),
 (12, 11, 73),
 (13, 11, 80),
 (14, 11, 60),
 (15, 11, 95),
 (16, 11, 78),
 (17, 11, 86),
 (18, 11, 68),
 (19, 11, 90),
 (20, 11, 71),
 (21, 11, 82),
 (22, 11, 64),
 (23, 11, 94),
 (24, 11, 79),
 (25, 11, 87),
 (26, 11, 61),
 (27, 11, 96);
		 
-- StudentId =12 
INSERT INTO Grades   
VALUES
(2, 12, 65),
  (3, 12, 82),
  (5, 12, 70),
  (6, 12, 94),
  (7, 12, 61),
  (8, 12, 88),
  (9, 12, 75),
 (10, 12, 92),
 (11, 12, 69),
 (12, 12, 80),
 (13, 12, 73),
 (14, 12, 96),
 (15, 12, 63),
 (16, 12, 85),
 (17, 12, 76),
 (18, 12, 99),
 (19, 12, 67),
 (20, 12, 81),
 (21, 12, 74),
 (22, 12, 97),
 (23, 12, 62),
 (24, 12, 86),
 (25, 12, 77),
 (26, 12, 91),
 (27, 12, 60);
			  



Go

--Write a SELECT query to list all courses.

GO
Select * From Coursers;

Go

--Write a SELECT query to find all assignments for a specific course

GO

select * from Assignments 
where CourseId=6;


GO


--Write a SELECT query to find all students (users with the role 'Student').

GO
select  *from Users
where Role='student'


GO

--Write an UPDATE statement to change a student's role.


GO
update Users
set Role='Teacher'
where UserID=2;



GO
--Write a DELETE statement to remove a specific comment.


GO
Delete from Comments
where CommentId=1;


Go

--Write a query to list all students along with their grades for a specific course.

GO

Select Users.* ,Grades.Grade 
from Users
JOIN Grades
on Grades.StudentId = Users.UserID
JOIN
Assignments 
on Assignments.AssignmentId = Grades.AssignmentId
JOIN 
Coursers 
ON Coursers.CourseID = Assignments.CourseId
where Coursers.CourseID=14
 

GO

--Write a query to calculate the average grade for each course.

GO

select  Coursers.CourseID,AVG(Grades.Grade) as Average
From Grades
JOIN Assignments
ON Assignments.AssignmentId = Grades.AssignmentId
JOIN Coursers 
ON Assignments.CourseId = Coursers.CourseID
group by Coursers.CourseId


GO

 --Write a query to list all courses with their respective syllabuses.

 GO
Select Coursers.* ,Syllabus.*
from Coursers
 JOIN Syllabus ON Syllabus.SyllabusId =Coursers.SyllabusId
;


GO
--Write a query to find all comments for a specific course.

GO

Select Comments.*
from Comments 
JOIN Assignments
ON Assignments.AssignmentId = Comments.AssignmentId
JOIN 
Coursers 
ON Coursers.CourseID =Assignments.CourseId
Where Coursers.CourseID=6
;


GO

--Create a stored procedure to add a new student.

GO
Create Procedure Add_Student
    @UserName VARCHAR(64),
    @FirstName VARCHAR(64),
    @LastName VARCHAR(64),
    @EmailAddress VARCHAR(128),
    @PhoneNumber VARCHAR(16)
AS
BEGIN
    INSERT INTO Users
    VALUES
    (
        @UserName,
        @FirstName,
        @LastName,
        @EmailAddress,
        @PhoneNumber,
		'Student'
    );
END;
GO

exec Add_Student
    @UserName = 'Ali123',
    @FirstName = 'Ali',
    @LastName = 'Ahmad',
    @EmailAddress = 'ali@example.com',
    @PhoneNumber = '0999999999';
	 
	GO

	--Create a stored procedure to add a new Assignment. Make sure the course assignments weights don t go above 100.

	GO	 
 CREATE PROCEDURE Add_Assignment
    @CourseId INT,
    @AssignmentTitle VARCHAR(100),
    @Description VARCHAR(500),
    @Weight INT,
    @MaxGrade INT,
    @DueDate DATE
AS
BEGIN

    IF @Weight > 100
    BEGIN
        PRINT 'Weight cannot be greater than 100';
        RETURN;
    END

    INSERT INTO Assignments
    VALUES
    (
        @CourseId,
        @AssignmentTitle,
        @Description,
        @Weight,
        @MaxGrade,
        @DueDate
    );

END

GO

--Calculate function to calculate the Student Grade in a Course. Return  A', 'B , etc 

GO
CREATE FUNCTION GetStudentGrade
(
    @StudentId INT,
    @CourseId INT
)
RETURNS CHAR(2)
AS
BEGIN

    DECLARE @FinalGrade DECIMAL(5,2);

    SELECT @FinalGrade =
        SUM((g.Grade * 100.0 / a.MaxGrade) * a.Weight / 100.0)
    FROM Grades g
    JOIN Assignments a
        ON a.AssignmentId = g.AssignmentId
    WHERE g.StudentId = @StudentId
      AND a.CourseId = @CourseId;

    RETURN
    (
        CASE
            WHEN @FinalGrade >= 90 THEN 'A'
            WHEN @FinalGrade >= 80 THEN 'B'
            WHEN @FinalGrade >= 70 THEN 'C'
            WHEN @FinalGrade >= 60 THEN 'D'
            ELSE 'F'
        END
    );

END;
GO

SELECT dbo.GetStudentGrade(5, 14) ;
GO


--Create a function to calculate the GPA of a student.

GO
CREATE FUNCTION GetStudentGPA
(
    @StudentId INT
)
RETURNS DECIMAL(3,2)
AS
BEGIN

    DECLARE @AverageGrade DECIMAL(5,2);
    DECLARE @GPA DECIMAL(3,2);

    SELECT @AverageGrade = AVG(Grade)
    FROM Grades
    WHERE StudentId = @StudentId;

    SET @GPA = (@AverageGrade / 100.0) * 4.0;

    RETURN @GPA;

END;
GO

SELECT dbo.GetStudentGPA(2) ;

GO