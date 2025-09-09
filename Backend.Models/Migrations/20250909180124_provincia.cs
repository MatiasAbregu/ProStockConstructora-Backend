using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class provincia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "090f8906-d60f-48f7-8d4a-7c52f9ee041b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7519a275-21ac-4696-99b6-503da1eafa57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b44c1dec-d920-454d-80b1-8861863af9a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cadb2e29-0331-404f-a010-e1849760dfb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c201591-0aa8-425f-8741-7e4e66782503", null, "Administrador", "Administrador" },
                    { "81199a65-f786-41d1-bde4-e1686490c8fb", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "9360fc67-239b-4905-99ef-b995170deeff", null, "Superadministrador", "Superadministrador" },
                    { "94a3ab26-1b37-4662-ac63-9584d5e2f8e3", null, "JefeDeObra", "JefeDeObra" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c201591-0aa8-425f-8741-7e4e66782503");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81199a65-f786-41d1-bde4-e1686490c8fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9360fc67-239b-4905-99ef-b995170deeff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a3ab26-1b37-4662-ac63-9584d5e2f8e3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "090f8906-d60f-48f7-8d4a-7c52f9ee041b", null, "JefeDeObra", "JefeDeObra" },
                    { "7519a275-21ac-4696-99b6-503da1eafa57", null, "Superadministrador", "Superadministrador" },
                    { "b44c1dec-d920-454d-80b1-8861863af9a0", null, "Administrador", "Administrador" },
                    { "cadb2e29-0331-404f-a010-e1849760dfb4", null, "JefeDeDeposito", "JefeDeDeposito" }
                });
        }
    }
}
