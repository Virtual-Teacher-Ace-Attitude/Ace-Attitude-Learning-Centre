using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AceAttitude.Data.Migrations
{
    public partial class FixRoleSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "ModifiedOn", "Name", "NormalizedName" },
                values: new object[] { "1", "9598b3bd-c655-4ed5-91a2-892dacfb2b06", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "ModifiedOn", "Name", "NormalizedName" },
                values: new object[] { "2", "cb744fcb-4aaf-43e4-a55d-73424c80b5f2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "ModifiedOn", "Name", "NormalizedName" },
                values: new object[] { "3", "437c4d3b-ddd9-465d-acc3-a7d586b60938", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Admin", "ADMIN" });
        }
    }
}
