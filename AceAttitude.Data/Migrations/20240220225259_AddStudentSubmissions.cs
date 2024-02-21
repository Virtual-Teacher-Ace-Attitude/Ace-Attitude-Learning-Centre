using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AceAttitude.Data.Migrations
{
    public partial class AddStudentSubmissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentSubmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LectureId1 = table.Column<int>(type: "int", nullable: false),
                    LectureId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubmissions_Lectures_LectureId1",
                        column: x => x.LectureId1,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubmissions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 7, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 26, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 27, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "CreatedOn", "Likes" },
                values: new object[] { "I found the first lecture very informative. Looking forward to the rest of the course!", new DateTime(2024, 2, 22, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), 5 });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "CreatedOn", "Likes" },
                values: new object[] { "The workshop materials are comprehensive and well-organized. Enjoying the learning experience!", new DateTime(2024, 3, 6, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), 7 });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "CreatedOn", "Likes" },
                values: new object[] { "The masterclass has inspired me to start working on my novel. Thank you!", new DateTime(2024, 3, 24, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), 10 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Description", "Level", "StartingDate", "Title" },
                values: new object[] { new DateTime(2024, 2, 21, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "This course introduces basic English and phonics to pre-school children.", 0, new DateTime(2024, 2, 21, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "Oxford Adventurers" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Description", "StartingDate", "Title" },
                values: new object[] { new DateTime(2024, 2, 28, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "This course prepares secondary school students for their first certificate exam.", new DateTime(2024, 3, 21, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "First Certificate for Schools" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Description", "StartingDate", "Title" },
                values: new object[] { new DateTime(2024, 3, 21, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "Unlock your creativity with this masterclass on creative writing techniques and storytelling.", new DateTime(2024, 4, 21, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "Creative Writing Masterclass" });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 21, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "Teaches kids basic vocabulary related to the classroom and classroom activities.", "Classroom Language" });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 22, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "A speaking-oriented lecture for teenagers.", "Introductions and Icebreakers" });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "An in-depth analysis of classic and contemporary literary works.", "Literature Appreciation" });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTime(2024, 2, 24, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), 4.8m });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTime(2024, 2, 25, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), 4.6m });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTime(2024, 2, 26, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), 4.7m });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 17, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 1, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 2, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                columns: new[] { "CreatedOn", "Email", "FirstName", "LastName" },
                values: new object[] { new DateTime(2024, 2, 22, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "john.doe@example.com", "John", "Doe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                columns: new[] { "CreatedOn", "Email", "FirstName", "LastName" },
                values: new object[] { new DateTime(2024, 2, 21, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "alexander.arabadzhiev@example.com", "Alexander", "Arabadzhiev" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                columns: new[] { "CreatedOn", "Email", "FirstName", "LastName" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "emily.jackson@example.com", "Emily", "Jackson" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                columns: new[] { "CreatedOn", "Email", "FirstName", "LastName" },
                values: new object[] { new DateTime(2024, 2, 21, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "sarah.smith@example.com", "Sarah", "Smith" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                columns: new[] { "CreatedOn", "Email" },
                values: new object[] { new DateTime(2024, 2, 23, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "georgi.aleksandrov@example.com" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                columns: new[] { "CreatedOn", "Email", "FirstName", "LastName" },
                values: new object[] { new DateTime(2024, 2, 22, 0, 52, 58, 492, DateTimeKind.Local).AddTicks(7012), "alexei.kalionski@example.com", "Mathilda", "Brown" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubmissions_LectureId1",
                table: "StudentSubmissions",
                column: "LectureId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubmissions_StudentId",
                table: "StudentSubmissions",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubmissions");

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 17, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 2, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 21, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 22, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "CreatedOn", "Likes" },
                values: new object[] { "Content of comment 1.", new DateTime(2024, 2, 17, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), 1 });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "CreatedOn", "Likes" },
                values: new object[] { "Content of comment 2.", new DateTime(2024, 3, 1, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), 2 });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "CreatedOn", "Likes" },
                values: new object[] { "Content of comment 3.", new DateTime(2024, 3, 19, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), 3 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Description", "Level", "StartingDate", "Title" },
                values: new object[] { new DateTime(2024, 2, 16, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "Description of course 1.", 1, new DateTime(2024, 2, 16, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "Course 1" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Description", "StartingDate", "Title" },
                values: new object[] { new DateTime(2024, 2, 23, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "Description of course 2.", new DateTime(2024, 3, 16, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "Course 2" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Description", "StartingDate", "Title" },
                values: new object[] { new DateTime(2024, 3, 16, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "Description of course 3.", new DateTime(2024, 4, 16, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "Course 3" });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 16, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "Description of lecture 1.", "Lecture 1" });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 17, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "Description of lecture 2.", "Lecture 2" });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 18, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "Description of lecture 3.", "Lecture 3" });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTime(2024, 2, 19, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), 5.0m });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTime(2024, 2, 20, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), 4.5m });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Value" },
                values: new object[] { new DateTime(2024, 2, 21, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), 4.5m });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 13, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 12, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 11, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 24, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 25, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 26, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                columns: new[] { "CreatedOn", "Email", "FirstName", "LastName" },
                values: new object[] { new DateTime(2024, 2, 17, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "student2@abv.bg", "Student", "Two" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                columns: new[] { "CreatedOn", "Email", "FirstName", "LastName" },
                values: new object[] { new DateTime(2024, 2, 16, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "teacher1@abv.bg", "Alexei", "Kalionski" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                columns: new[] { "CreatedOn", "Email", "FirstName", "LastName" },
                values: new object[] { new DateTime(2024, 2, 18, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "student3@abv.bg", "Student", "Three" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                columns: new[] { "CreatedOn", "Email", "FirstName", "LastName" },
                values: new object[] { new DateTime(2024, 2, 16, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "student1@abv.bg", "Student", "One" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                columns: new[] { "CreatedOn", "Email" },
                values: new object[] { new DateTime(2024, 2, 18, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "teacher3@abv.bg" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                columns: new[] { "CreatedOn", "Email", "FirstName", "LastName" },
                values: new object[] { new DateTime(2024, 2, 17, 17, 5, 25, 381, DateTimeKind.Local).AddTicks(8288), "teacher2@abv.bg", "Alexander", "Arabadzhiev" });
        }
    }
}
