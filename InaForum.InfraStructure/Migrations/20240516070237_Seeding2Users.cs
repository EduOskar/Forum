using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InaForum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeding2Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("63013afe-1c25-4c4b-a4ba-46be2eae56d8"), "Oskar@Mail.com", "Oskar", "Ahling", "Hejsan123!", "Klade" },
                    { new Guid("72eec07e-6053-4f79-af78-2596f7f294d2"), "Ina@Mail.com", "Ina", "Nilsson", "Hejsan123!", "Nubbebub" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("63013afe-1c25-4c4b-a4ba-46be2eae56d8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("72eec07e-6053-4f79-af78-2596f7f294d2"));
        }
    }
}
