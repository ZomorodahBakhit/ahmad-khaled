using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task2.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Syllabus",
                columns: table => new
                {
                    SyllabusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Syllabus__9B8016A6BC42B6D4", x => x.SyllabusId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    Role = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Coursers",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true),
                    StarteDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SyllabusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Coursers__C92D71877F3C3C3A", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Coursers_Syllabus",
                        column: x => x.SyllabusId,
                        principalTable: "Syllabus",
                        principalColumn: "SyllabusId");
                    table.ForeignKey(
                        name: "FK_Coursers_Users",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    AssignmentTitle = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    MaxGrade = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Assignme__32499E77F66859D5", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_Coursers",
                        column: x => x.CourseId,
                        principalTable: "Coursers",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedeByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CommentContent = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__C3B4DFCA5E277882", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK__Comments__Assign__412EB0B6",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId");
                    table.ForeignKey(
                        name: "FK__Comments__Create__4222D4EF",
                        column: x => x.CreatedeByUserId,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Grades__54F87A5783E53AE4", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grades_Assignments",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId");
                    table.ForeignKey(
                        name: "FK_Grades_Users",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseId",
                table: "Assignments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AssignmentId",
                table: "Comments",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedeByUserId",
                table: "Comments",
                column: "CreatedeByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Coursers_SyllabusId",
                table: "Coursers",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_Coursers_TeacherId",
                table: "Coursers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_AssignmentId",
                table: "Grades",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "EmailAddress_Users_unique",
                table: "Users",
                column: "EmailAddress",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Coursers");

            migrationBuilder.DropTable(
                name: "Syllabus");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
