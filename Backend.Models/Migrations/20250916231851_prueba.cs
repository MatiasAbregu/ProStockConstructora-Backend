using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7285a1be-c843-49e5-b063-7f1b1879a2da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78abbb91-2d1f-4297-a241-2af60252458e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "918f3357-cb83-4e6a-8f9c-bdf4eeda5060");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce9374ca-dd00-4e42-94da-41367aec7cdf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23fe31fa-efbc-4c12-99d2-f37cdffc60a8", null, "Superadministrador", "Superadministrador" },
                    { "70995920-2942-40c8-b4a0-c3ba23513af8", null, "Administrador", "Administrador" },
                    { "e3b908d7-99d8-4dbd-aceb-6f801be94de4", null, "JefeDeObra", "JefeDeObra" },
                    { "e8d77b09-d8c0-4dae-bdae-68579e748105", null, "JefeDeDeposito", "JefeDeDeposito" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23fe31fa-efbc-4c12-99d2-f37cdffc60a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70995920-2942-40c8-b4a0-c3ba23513af8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3b908d7-99d8-4dbd-aceb-6f801be94de4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8d77b09-d8c0-4dae-bdae-68579e748105");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7285a1be-c843-49e5-b063-7f1b1879a2da", null, "JefeDeObra", "JefeDeObra" },
                    { "78abbb91-2d1f-4297-a241-2af60252458e", null, "Administrador", "Administrador" },
                    { "918f3357-cb83-4e6a-8f9c-bdf4eeda5060", null, "Superadministrador", "Superadministrador" },
                    { "ce9374ca-dd00-4e42-94da-41367aec7cdf", null, "JefeDeDeposito", "JefeDeDeposito" }
                });
        }
    }
}
