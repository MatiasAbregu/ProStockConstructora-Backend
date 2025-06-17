using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class addinguniqueColumnEnterprise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55c386f3-8615-400c-8308-97dff9975f66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e157528-ef4f-43c4-b7f7-c08999d6fe20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fdbc976-0a0a-4347-8b8b-c259eb9a7721");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6845be0-8bc8-47db-871c-ebbbc32427e1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0adf6769-14fa-4d6e-ba21-b79203f5176f", null, "Superadministrador", "Superadministrador" },
                    { "7ad28659-b37c-40c3-8654-c4c02c343d40", null, "Administrador", "Administrador" },
                    { "b7143934-b5fa-4520-bb56-c957d9eaf46d", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "f527bf70-bff9-47b6-a5e5-056c13d90884", null, "JefeDeObra", "JefeDeObra" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_NombreEmpresa",
                table: "Empresa",
                column: "NombreEmpresa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Empresa_NombreEmpresa",
                table: "Empresa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0adf6769-14fa-4d6e-ba21-b79203f5176f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ad28659-b37c-40c3-8654-c4c02c343d40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7143934-b5fa-4520-bb56-c957d9eaf46d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f527bf70-bff9-47b6-a5e5-056c13d90884");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "55c386f3-8615-400c-8308-97dff9975f66", null, "Superadministrador", "Superadministrador" },
                    { "5e157528-ef4f-43c4-b7f7-c08999d6fe20", null, "Administrador", "Administrador" },
                    { "7fdbc976-0a0a-4347-8b8b-c259eb9a7721", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "b6845be0-8bc8-47db-871c-ebbbc32427e1", null, "JefeDeObra", "JefeDeObra" }
                });
        }
    }
}
