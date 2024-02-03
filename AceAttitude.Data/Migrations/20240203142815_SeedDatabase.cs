using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AceAttitude.Data.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "CreatedOn", "DeletedOn", "ModifiedOn" },
                values: new object[,]
                {
                    { "11d15832-b94e-4be4-a892-14a07641adc3", "11d15832-b94e-4be4-a892-14a07641adc3", new DateTime(2024, 2, 4, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, null },
                    { "5422e8d8-d114-42b1-b878-f410f14e0be7", "5422e8d8-d114-42b1-b878-f410f14e0be7", new DateTime(2024, 2, 5, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, null },
                    { "64dfe826-08e8-4dcf-888b-c441fead8803", "64dfe826-08e8-4dcf-888b-c441fead8803", new DateTime(2024, 2, 3, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ApplicationUserId", "CreatedOn", "DeletedOn", "IsAdmin", "ModifiedOn" },
                values: new object[,]
                {
                    { "22cbe4de-2827-4458-b55f-779a19400ab5", "22cbe4de-2827-4458-b55f-779a19400ab5", new DateTime(2024, 2, 3, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, true, null },
                    { "89beab74-07ac-446a-8dc6-b0291b5ff68b", "89beab74-07ac-446a-8dc6-b0291b5ff68b", new DateTime(2024, 2, 5, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, false, null },
                    { "aba81718-3f23-42ca-ba84-fcd9b4f4f944", "aba81718-3f23-42ca-ba84-fcd9b4f4f944", new DateTime(2024, 2, 4, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, true, null }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AgeGroup", "CreatedOn", "DeletedOn", "Description", "IsCompleted", "IsDraft", "Level", "ModifiedOn", "Rating", "StartingDate", "TeacherId", "Title" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 2, 3, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, "Description of course 1.", true, false, 1, null, null, new DateTime(2024, 2, 3, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), "22cbe4de-2827-4458-b55f-779a19400ab5", "Course 1" },
                    { 2, 1, new DateTime(2024, 2, 10, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, "Description of course 2.", false, false, 3, null, null, new DateTime(2024, 3, 3, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), "aba81718-3f23-42ca-ba84-fcd9b4f4f944", "Course 2" },
                    { 3, 2, new DateTime(2024, 3, 3, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, "Description of course 3.", false, true, 5, null, null, new DateTime(2024, 4, 3, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), "89beab74-07ac-446a-8dc6-b0291b5ff68b", "Course 3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Email", "FirstName", "LastName", "ModifiedOn", "NoteFilePath", "PasswordHash", "PictureFilePath", "StudentId", "TeacherId" },
                values: new object[,]
                {
                    { "11d15832-b94e-4be4-a892-14a07641adc3", new DateTime(2024, 2, 4, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, "student2@abv.bg", "Student", "Two", null, null, "2a$11$2Wp6Wd8XCZRnMj9WoPYeCeiQTL9Xv7OQmYtaiKgGCvmUzgbUUYQsa", null, "11d15832-b94e-4be4-a892-14a07641adc3", null },
                    { "22cbe4de-2827-4458-b55f-779a19400ab5", new DateTime(2024, 2, 3, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, "teacher1@abv.bg", "Alexei", "Kalionski", null, null, "2a$11$2Wp6Wd8XCZRnMj9WoPYeCeiQTL9Xv7OQmYtaiKgGCvmUzgbUUYQsa", null, null, "22cbe4de-2827-4458-b55f-779a19400ab5" },
                    { "5422e8d8-d114-42b1-b878-f410f14e0be7", new DateTime(2024, 2, 5, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, "student3@abv.bg", "Student", "Three", null, null, "2a$11$2Wp6Wd8XCZRnMj9WoPYeCeiQTL9Xv7OQmYtaiKgGCvmUzgbUUYQsa", null, "5422e8d8-d114-42b1-b878-f410f14e0be7", null },
                    { "64dfe826-08e8-4dcf-888b-c441fead8803", new DateTime(2024, 2, 3, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, "student1@abv.bg", "Student", "One", null, null, "2a$11$2Wp6Wd8XCZRnMj9WoPYeCeiQTL9Xv7OQmYtaiKgGCvmUzgbUUYQsa", null, "64dfe826-08e8-4dcf-888b-c441fead8803", null },
                    { "89beab74-07ac-446a-8dc6-b0291b5ff68b", new DateTime(2024, 2, 5, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, "teacher3@abv.bg", "Georgi", "Aleksandrov", null, null, "2a$11$2Wp6Wd8XCZRnMj9WoPYeCeiQTL9Xv7OQmYtaiKgGCvmUzgbUUYQsa", null, null, "89beab74-07ac-446a-8dc6-b0291b5ff68b" },
                    { "aba81718-3f23-42ca-ba84-fcd9b4f4f944", new DateTime(2024, 2, 4, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, "teacher2@abv.bg", "Alexander", "Arabadzhiev", null, null, "2a$11$2Wp6Wd8XCZRnMj9WoPYeCeiQTL9Xv7OQmYtaiKgGCvmUzgbUUYQsa", null, null, "aba81718-3f23-42ca-ba84-fcd9b4f4f944" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ApplicationUserId", "Content", "CourseId", "CreatedOn", "DeletedOn", "Likes", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, "64dfe826-08e8-4dcf-888b-c441fead8803", "Content of comment 1.", 1, new DateTime(2024, 2, 4, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, 1, null },
                    { 2, "11d15832-b94e-4be4-a892-14a07641adc3", "Content of comment 2.", 2, new DateTime(2024, 2, 17, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, 2, null },
                    { 3, "5422e8d8-d114-42b1-b878-f410f14e0be7", "Content of comment 3.", 3, new DateTime(2024, 3, 6, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, 3, null }
                });

            migrationBuilder.InsertData(
                table: "Lectures",
                columns: new[] { "Id", "CourseId", "CreatedOn", "DeletedOn", "Description", "ModifiedOn", "TextFilePath", "Title", "VideoFilePath" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 3, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, "Description of lecture 1.", null, null, "Lecture 1", null },
                    { 2, 2, new DateTime(2024, 2, 4, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, "Description of lecture 2.", null, null, "Lecture 2", null },
                    { 3, 3, new DateTime(2024, 2, 5, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), null, "Description of lecture 3.", null, null, "Lecture 3", null }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "CourseId", "CreatedOn", "IsRated", "StudentId", "Value" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 6, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), true, "64dfe826-08e8-4dcf-888b-c441fead8803", 5.0m },
                    { 2, 1, new DateTime(2024, 2, 7, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), true, "11d15832-b94e-4be4-a892-14a07641adc3", 4.5m },
                    { 3, 1, new DateTime(2024, 2, 8, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), false, "5422e8d8-d114-42b1-b878-f410f14e0be7", 4.5m }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "CreatedOn", "IsCompleted", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 31, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), true, "64dfe826-08e8-4dcf-888b-c441fead8803" },
                    { 2, 1, new DateTime(2024, 1, 30, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), true, "11d15832-b94e-4be4-a892-14a07641adc3" },
                    { 3, 1, new DateTime(2024, 1, 29, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), true, "5422e8d8-d114-42b1-b878-f410f14e0be7" },
                    { 4, 2, new DateTime(2024, 2, 11, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), false, "64dfe826-08e8-4dcf-888b-c441fead8803" },
                    { 5, 2, new DateTime(2024, 2, 12, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), false, "11d15832-b94e-4be4-a892-14a07641adc3" },
                    { 6, 2, new DateTime(2024, 2, 13, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), false, "5422e8d8-d114-42b1-b878-f410f14e0be7" }
                });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "Id", "ApplicationUserId", "CommentId", "CreatedOn", "IsLiked" },
                values: new object[,]
                {
                    { 1, "64dfe826-08e8-4dcf-888b-c441fead8803", 1, new DateTime(2024, 2, 4, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), true },
                    { 2, "11d15832-b94e-4be4-a892-14a07641adc3", 2, new DateTime(2024, 2, 18, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), true },
                    { 3, "5422e8d8-d114-42b1-b878-f410f14e0be7", 3, new DateTime(2024, 3, 8, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), true },
                    { 4, "89beab74-07ac-446a-8dc6-b0291b5ff68b", 3, new DateTime(2024, 3, 9, 16, 28, 15, 233, DateTimeKind.Local).AddTicks(7547), false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Lectures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
