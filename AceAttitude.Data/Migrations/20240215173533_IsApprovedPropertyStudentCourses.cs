using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AceAttitude.Data.Migrations
{
    public partial class IsApprovedPropertyStudentCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "StudentCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 1, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 20, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 21, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 29, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 18, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 15, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866), new DateTime(2024, 2, 15, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 22, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866), new DateTime(2024, 3, 15, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 3, 15, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866), new DateTime(2024, 4, 15, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866) });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 17, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 19, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 20, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "IsApproved" },
                values: new object[] { new DateTime(2024, 2, 12, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866), true });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "IsApproved" },
                values: new object[] { new DateTime(2024, 2, 11, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866), true });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "IsApproved" },
                values: new object[] { new DateTime(2024, 2, 10, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866), true });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "IsApproved" },
                values: new object[] { new DateTime(2024, 2, 23, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866), true });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "IsApproved" },
                values: new object[] { new DateTime(2024, 2, 24, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866), true });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "IsApproved" },
                values: new object[] { new DateTime(2024, 2, 25, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866), true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 17, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 17, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 19, 35, 33, 319, DateTimeKind.Local).AddTicks(6866));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "StudentCourses");

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 9, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 13, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 14, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 9, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 22, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 11, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 8, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313), new DateTime(2024, 2, 8, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 15, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313), new DateTime(2024, 3, 8, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 3, 8, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313), new DateTime(2024, 4, 8, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313) });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 9, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 10, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 11, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 12, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 13, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 5, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 3, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 17, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 9, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 10, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 10, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 9, 21, 48, 3, 36, DateTimeKind.Local).AddTicks(4313));
        }
    }
}
