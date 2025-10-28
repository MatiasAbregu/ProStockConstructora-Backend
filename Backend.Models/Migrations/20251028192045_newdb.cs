using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a64a28d-439e-4228-9c63-cf159e71c318");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "808e5653-89dc-4bbb-a63d-a0a56d7cd17b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4d7a50d-1ffb-4e52-bf60-14c12299e588");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efb8c58a-8dab-4b91-83b9-848578d6166b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45ed6ccc-318f-4ffa-9e62-03dcde77c410", null, "Administrador", "ADMINISTRADOR" },
                    { "8191878d-01d9-4aa3-b598-0101f20c5a69", null, "Jefe de obra", "JEFEDEOBRA" },
                    { "99a440d2-1b6d-442e-a564-589bf86fef21", null, "Jefe de depósito", "JEFEDEDEPOSITO" },
                    { "a7af1bf2-41ed-478d-bc5d-ddf480aa402d", null, "Superadministrador", "SUPERADMINISTRADOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45ed6ccc-318f-4ffa-9e62-03dcde77c410");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8191878d-01d9-4aa3-b598-0101f20c5a69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99a440d2-1b6d-442e-a564-589bf86fef21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7af1bf2-41ed-478d-bc5d-ddf480aa402d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a64a28d-439e-4228-9c63-cf159e71c318", null, "Jefe de obra", "JEFEDEOBRA" },
                    { "808e5653-89dc-4bbb-a63d-a0a56d7cd17b", null, "Superadministrador", "SUPERADMINISTRADOR" },
                    { "e4d7a50d-1ffb-4e52-bf60-14c12299e588", null, "Administrador", "ADMINISTRADOR" },
                    { "efb8c58a-8dab-4b91-83b9-848578d6166b", null, "Jefe de depósito", "JEFEDEDEPOSITO" }
                });
        }
    }
}
