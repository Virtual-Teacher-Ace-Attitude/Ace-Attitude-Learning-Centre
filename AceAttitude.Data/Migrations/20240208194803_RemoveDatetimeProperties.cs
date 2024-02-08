using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AceAttitude.Data.Migrations
{
    public partial class RemoveDatetimeProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Students");

            migrationBuilder.AddColumn<bool>(
                name: "AwaitingPromotion",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPromoted",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwaitingPromotion",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsPromoted",
                table: "Students");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Teachers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Teachers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 21, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 11, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 20, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 9, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133), new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 2, 13, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133), new DateTime(2024, 3, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "StartingDate" },
                values: new object[] { new DateTime(2024, 3, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133), new DateTime(2024, 4, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133) });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 9, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 10, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 11, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 3, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 2, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 1, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 14, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11d15832-b94e-4be4-a892-14a07641adc3",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "22cbe4de-2827-4458-b55f-779a19400ab5",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5422e8d8-d114-42b1-b878-f410f14e0be7",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "64dfe826-08e8-4dcf-888b-c441fead8803",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 6, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "89beab74-07ac-446a-8dc6-b0291b5ff68b",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aba81718-3f23-42ca-ba84-fcd9b4f4f944",
                column: "CreatedOn",
                value: new DateTime(2024, 2, 7, 17, 25, 37, 860, DateTimeKind.Local).AddTicks(8133));
        }
    }
}
