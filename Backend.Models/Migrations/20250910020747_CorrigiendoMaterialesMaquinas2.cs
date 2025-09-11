using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class CorrigiendoMaterialesMaquinas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Materiales_TipoMaterialId",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materiales",
                table: "Materiales");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19940fba-0222-494b-80b0-e28c712d4f4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a1b8c22-f38d-48de-9095-16fdfc69aca8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4df0b14f-5339-41a8-8315-cf380fab9ee9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8bf2267-9037-4602-a1c4-18f30c8ac778");

            migrationBuilder.RenameTable(
                name: "Materiales",
                newName: "TipoMateriales");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoMateriales",
                table: "TipoMateriales",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a427d4d-ed4b-4412-9054-d043f9d35e75", null, "Superadministrador", "Superadministrador" },
                    { "52c232a7-09a3-4f7a-8e05-3eea6246306c", null, "JefeDeObra", "JefeDeObra" },
                    { "bb6dc87c-a552-4823-b27f-899a430141b8", null, "Administrador", "Administrador" },
                    { "d1ba1d6a-fa3b-431e-8d41-73d16a3bacd3", null, "JefeDeDeposito", "JefeDeDeposito" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_TipoMateriales_TipoMaterialId",
                table: "Stocks",
                column: "TipoMaterialId",
                principalTable: "TipoMateriales",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_TipoMateriales_TipoMaterialId",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoMateriales",
                table: "TipoMateriales");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a427d4d-ed4b-4412-9054-d043f9d35e75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52c232a7-09a3-4f7a-8e05-3eea6246306c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb6dc87c-a552-4823-b27f-899a430141b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1ba1d6a-fa3b-431e-8d41-73d16a3bacd3");

            migrationBuilder.RenameTable(
                name: "TipoMateriales",
                newName: "Materiales");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materiales",
                table: "Materiales",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19940fba-0222-494b-80b0-e28c712d4f4d", null, "Administrador", "Administrador" },
                    { "3a1b8c22-f38d-48de-9095-16fdfc69aca8", null, "Superadministrador", "Superadministrador" },
                    { "4df0b14f-5339-41a8-8315-cf380fab9ee9", null, "JefeDeObra", "JefeDeObra" },
                    { "f8bf2267-9037-4602-a1c4-18f30c8ac778", null, "JefeDeDeposito", "JefeDeDeposito" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Materiales_TipoMaterialId",
                table: "Stocks",
                column: "TipoMaterialId",
                principalTable: "Materiales",
                principalColumn: "Id");
        }
    }
}
