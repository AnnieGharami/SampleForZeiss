using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Platform.ApplicationServices.Migrations
{
    public partial class ModelsEmployeeContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "A1" },
                    { 2, "B2" },
                    { 3, "C3" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "System Engineer" },
                    { 3, "Test Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "FirstName", "LastName", "RoleId" },
                values: new object[] { 1, new DateTime(2021, 12, 3, 11, 11, 40, 896, DateTimeKind.Local).AddTicks(2511), 1, "John", "Doe", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "FirstName", "LastName", "RoleId" },
                values: new object[] { 2, new DateTime(2021, 12, 3, 11, 11, 40, 897, DateTimeKind.Local).AddTicks(6315), 2, "Jane", "Simmers", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "FirstName", "LastName", "RoleId" },
                values: new object[] { 3, new DateTime(2021, 12, 3, 11, 11, 40, 897, DateTimeKind.Local).AddTicks(6371), 1, "Anthony", "Dewar", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
