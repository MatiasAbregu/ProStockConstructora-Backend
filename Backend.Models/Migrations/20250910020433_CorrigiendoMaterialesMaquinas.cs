using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class CorrigiendoMaterialesMaquinas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maquinas");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63572425-0314-40ae-b825-46380a1b8d35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbbf753a-f4ec-4b78-81ce-4e884fac6bc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0f92d29-6859-436d-918a-39214158f28f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "faefe686-0e3d-44a7-ac64-7c1f7023c173");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Maquinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modelo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquinas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63572425-0314-40ae-b825-46380a1b8d35", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "cbbf753a-f4ec-4b78-81ce-4e884fac6bc0", null, "Administrador", "Administrador" },
                    { "d0f92d29-6859-436d-918a-39214158f28f", null, "JefeDeObra", "JefeDeObra" },
                    { "faefe686-0e3d-44a7-ac64-7c1f7023c173", null, "Superadministrador", "Superadministrador" }
                });
        }
    }
}
