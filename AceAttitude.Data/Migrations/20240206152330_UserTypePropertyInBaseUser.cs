using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AceAttitude.Data.Migrations
{
    public partial class UserTypePropertyInBaseUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 21, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 11, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 20, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 9, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 6, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613), new DateTime(2024, 2, 6, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 13, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613), new DateTime(2024, 3, 6, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 3, 6, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613), new DateTime(2024, 4, 6, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613) });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 9, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 10, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 11, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 3, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 2, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 1, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 14, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 23, 30, 343, DateTimeKind.Local).AddTicks(4613));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 19, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 9, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 10, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 7, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 4, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764), new DateTime(2024, 2, 4, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 11, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764), new DateTime(2024, 3, 4, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 3, 4, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764), new DateTime(2024, 4, 4, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764) });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 9, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 1, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 31, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 30, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 12, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 13, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 14, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 18, 52, 15, 712, DateTimeKind.Local).AddTicks(3764));
        }
    }
}
