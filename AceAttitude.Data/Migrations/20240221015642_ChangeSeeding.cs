using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AceAttitude.Data.Migrations
{
    public partial class ChangeSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 7, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 26, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 27, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 6, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 24, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Description", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 21, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401), "This course introduces fundamental English language skills and phonics to preschool children.", new DateTime(2024, 2, 21, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Description", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 28, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401), "This course thoroughly prepares high school students for their inaugural certification exam.", new DateTime(2024, 3, 21, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 3, 21, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401), new DateTime(2024, 4, 21, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401) });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 21, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 24, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 25, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 26, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 17, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 1, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 2, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 21, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 21, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 3, 56, 41, 634, DateTimeKind.Local).AddTicks(7401));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 7, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 26, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 27, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 6, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 24, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Description", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 21, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421), "This course introduces basic English and phonics to pre-school children.", new DateTime(2024, 2, 21, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Description", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 28, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421), "This course prepares secondary school students for their first certificate exam.", new DateTime(2024, 3, 21, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 3, 21, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421), new DateTime(2024, 4, 21, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421) });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 21, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 24, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 25, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 26, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 17, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 1, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 2, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 21, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 21, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 2, 44, 54, 167, DateTimeKind.Local).AddTicks(1421));
        }
    }
}
