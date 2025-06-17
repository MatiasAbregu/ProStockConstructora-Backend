using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class addinguniqueColumnEnterprisenowcorrectlyxd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "40d34d1e-4ecf-449f-8197-044756116e08", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "82093117-c500-4edc-acad-4b52fa062ad2", null, "Administrador", "Administrador" },
                    { "93a0d1e6-3a24-42a4-8254-ad3c6820cd7f", null, "Superadministrador", "Superadministrador" },
                    { "e960b851-5072-4b7f-acf5-7254f121d58f", null, "JefeDeObra", "JefeDeObra" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_CUIT",
                table: "Empresa",
                column: "CUIT",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Empresa_CUIT",
                table: "Empresa");

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
    }
}
