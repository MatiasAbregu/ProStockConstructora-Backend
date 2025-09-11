using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class ObraUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c306e31-3aa6-4734-9f3e-fce6aca71890");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56ef6b4f-84f8-451b-b017-9db08c6ec22b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf40144a-5860-4484-b6ab-682266ca8541");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c17bfa78-61b7-44c5-b4a6-f6ee926bafff");

            migrationBuilder.CreateTable(
                name: "Depositos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoDeposito = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ObraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20764f04-b6f9-47bd-b4e0-dd030663e1cb", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "331e1f45-f164-4db8-9f27-16eb3f24d102", null, "Administrador", "Administrador" },
                    { "948f4be2-7682-4711-a805-211b13e384ec", null, "Superadministrador", "Superadministrador" },
                    { "dca0cd29-2886-4a96-8b33-d769441d5d5e", null, "JefeDeObra", "JefeDeObra" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depositos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20764f04-b6f9-47bd-b4e0-dd030663e1cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "331e1f45-f164-4db8-9f27-16eb3f24d102");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "948f4be2-7682-4711-a805-211b13e384ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dca0cd29-2886-4a96-8b33-d769441d5d5e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c306e31-3aa6-4734-9f3e-fce6aca71890", null, "JefeDeObra", "JefeDeObra" },
                    { "56ef6b4f-84f8-451b-b017-9db08c6ec22b", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "bf40144a-5860-4484-b6ab-682266ca8541", null, "Superadministrador", "Superadministrador" },
                    { "c17bfa78-61b7-44c5-b4a6-f6ee926bafff", null, "Administrador", "Administrador" }
                });
        }
    }
}
