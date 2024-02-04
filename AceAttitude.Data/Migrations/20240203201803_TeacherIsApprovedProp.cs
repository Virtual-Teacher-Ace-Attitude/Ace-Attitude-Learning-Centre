using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AceAttitude.Data.Migrations
{
    public partial class TeacherIsApprovedProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 8, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 9, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 17, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 6, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 3, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879), new DateTime(2024, 2, 3, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 10, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879), new DateTime(2024, 3, 3, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 3, 3, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879), new DateTime(2024, 4, 3, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879) });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 3, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 31, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 30, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 29, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 11, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 12, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 13, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 3, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                columns: new[] { "CreatedOn", "IsApproved" },
                values: new object[] { new DateTime(2024, 2, 3, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879), true });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                columns: new[] { "CreatedOn", "IsApproved" },
                values: new object[] { new DateTime(2024, 2, 5, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879), true });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                columns: new[] { "CreatedOn", "IsApproved" },
                values: new object[] { new DateTime(2024, 2, 4, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879), true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 3, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 3, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 22, 18, 3, 389, DateTimeKind.Local).AddTicks(9879));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Teachers");

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 8, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 9, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 17, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 6, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 3, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801), new DateTime(2024, 2, 3, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 10, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801), new DateTime(2024, 3, 3, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 3, 3, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801), new DateTime(2024, 4, 3, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801) });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 3, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 31, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 30, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 29, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 11, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 12, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 13, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 3, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 3, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 3, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 3, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 18, 58, 25, 696, DateTimeKind.Local).AddTicks(3801));
        }
    }
}
