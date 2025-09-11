using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class Obra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "122a4c37-d936-4ff4-807a-ffc67ad528d8", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "19feb170-2371-4be7-bc2a-260d67c3b8fb", null, "Superadministrador", "Superadministrador" },
                    { "cb30e974-83d7-4780-9851-617b50aac95f", null, "Administrador", "Administrador" },
                    { "cb84bd11-d5e6-418e-a8d1-75ffeaa275d9", null, "JefeDeObra", "JefeDeObra" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "122a4c37-d936-4ff4-807a-ffc67ad528d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19feb170-2371-4be7-bc2a-260d67c3b8fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb30e974-83d7-4780-9851-617b50aac95f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb84bd11-d5e6-418e-a8d1-75ffeaa275d9");

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
    }
}
