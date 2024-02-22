using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AceAttitude.Data.Migrations
{
    public partial class AdditionalSeedChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 8, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 27, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 7, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 25, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 22, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238), new DateTime(2024, 2, 22, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 29, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238), new DateTime(2024, 3, 22, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 3, 22, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238), new DateTime(2024, 4, 22, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "StartingDate", "Title" },
                values: new object[] { new DateTime(2024, 2, 22, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238), new DateTime(2024, 2, 22, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238), "Public Speaking" });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 24, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 25, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 26, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 27, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 19, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 17, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 2, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 3, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 24, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 24, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 0, 36, 0, 643, DateTimeKind.Local).AddTicks(2238));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 8, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 27, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 7, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 25, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 22, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184), new DateTime(2024, 2, 22, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 29, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184), new DateTime(2024, 3, 22, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 3, 22, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184), new DateTime(2024, 4, 22, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "StartingDate", "Title" },
                values: new object[] { new DateTime(2024, 2, 22, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184), new DateTime(2024, 2, 22, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184), "Oxford Adventurers" });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 24, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 25, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 26, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 27, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 19, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 17, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 2, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 3, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 24, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 24, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 0, 29, 0, 543, DateTimeKind.Local).AddTicks(9184));
        }
    }
}
