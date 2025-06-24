using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class BasedeDatosV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40d34d1e-4ecf-449f-8197-044756116e08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82093117-c500-4edc-acad-4b52fa062ad2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93a0d1e6-3a24-42a4-8254-ad3c6820cd7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e960b851-5072-4b7f-acf5-7254f121d58f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "74eae568-37c7-4470-8e93-107c8a5df172", null, "Superadministrador", "Superadministrador" },
                    { "97604729-66af-4b14-aec2-d1332482c90a", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "9d4a0e60-d81e-41b5-9447-c1fb40333a1a", null, "JefeDeObra", "JefeDeObra" },
                    { "d872cc8b-eafa-4023-b2f4-0c6980e7f534", null, "Administrador", "Administrador" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74eae568-37c7-4470-8e93-107c8a5df172");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97604729-66af-4b14-aec2-d1332482c90a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d4a0e60-d81e-41b5-9447-c1fb40333a1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d872cc8b-eafa-4023-b2f4-0c6980e7f534");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40d34d1e-4ecf-449f-8197-044756116e08", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "82093117-c500-4edc-acad-4b52fa062ad2", null, "Administrador", "Administrador" },
                    { "93a0d1e6-3a24-42a4-8254-ad3c6820cd7f", null, "Superadministrador", "Superadministrador" },
                    { "e960b851-5072-4b7f-acf5-7254f121d58f", null, "JefeDeObra", "JefeDeObra" }
                });
        }
    }
}
