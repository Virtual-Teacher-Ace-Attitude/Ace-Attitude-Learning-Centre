using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AceAttitude.Data.Migrations
{
    public partial class FixIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3adfb43f-5a80-44f5-b5c1-3c2a5c1d8c03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44dc7c9c-de0a-46a7-8374-a26f90b42253");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0fb8cb0-05b8-49c7-8245-1972c6443509");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AspNetRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "ModifiedOn", "Name", "NormalizedName" },
                values: new object[] { "3adfb43f-5a80-44f5-b5c1-3c2a5c1d8c03", "d1da79ae-e6c2-4756-86a5-a28f86f0a79c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "ModifiedOn", "Name", "NormalizedName" },
                values: new object[] { "44dc7c9c-de0a-46a7-8374-a26f90b42253", "5308e9bf-4528-4fa0-83b8-52fd8f9073ec", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "ModifiedOn", "Name", "NormalizedName" },
                values: new object[] { "c0fb8cb0-05b8-49c7-8245-1972c6443509", "965c3d49-ed5b-4073-866d-95d44e5b4c0a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Student", "STUDENT" });
        }
    }
}
