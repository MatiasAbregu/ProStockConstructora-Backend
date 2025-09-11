using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class Deposito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreObra = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    UbicacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obras");

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
    }
}
