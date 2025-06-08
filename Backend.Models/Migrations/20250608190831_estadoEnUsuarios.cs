using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class estadoEnUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Contacto_ContactoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Contacto_ContactoId",
                table: "Empresa");

            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_ContactoId",
                table: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ContactoId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ba4db7a-e91b-49da-8a6d-c65153554f56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46c7e996-2f55-4e0a-b69a-764d2026f670");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828e31aa-6026-4b2c-a9c6-27994b24aae2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe918c27-ea4f-4ad6-8120-bc3f03b32b22");

            migrationBuilder.DropColumn(
                name: "ContactoId",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "ContactoId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Empresa",
                type: "varchar(80)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Empresa",
                type: "varchar(120)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50980b49-7265-44ce-b638-23be12cfac5c", null, "Administrador", "Administrador" },
                    { "57a0726e-2a69-478f-b39b-f69658616b77", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "c3eb8626-6e84-435d-bf14-aba307a81186", null, "Superadministrador", "Superadministrador" },
                    { "dfca01f9-2e50-4e79-bf04-551ed39e2a3c", null, "JefeDeObra", "JefeDeObra" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50980b49-7265-44ce-b638-23be12cfac5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57a0726e-2a69-478f-b39b-f69658616b77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3eb8626-6e84-435d-bf14-aba307a81186");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfca01f9-2e50-4e79-bf04-551ed39e2a3c");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ContactoId",
                table: "Empresa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContactoId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Celular = table.Column<string>(type: "varchar(80)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(120)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ba4db7a-e91b-49da-8a6d-c65153554f56", null, "JefeDeObra", null },
                    { "46c7e996-2f55-4e0a-b69a-764d2026f670", null, "Administrador", null },
                    { "828e31aa-6026-4b2c-a9c6-27994b24aae2", null, "JefeDeDeposito", null },
                    { "fe918c27-ea4f-4ad6-8120-bc3f03b32b22", null, "Superadministrador", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_ContactoId",
                table: "Empresa",
                column: "ContactoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ContactoId",
                table: "AspNetUsers",
                column: "ContactoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Contacto_ContactoId",
                table: "AspNetUsers",
                column: "ContactoId",
                principalTable: "Contacto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Contacto_ContactoId",
                table: "Empresa",
                column: "ContactoId",
                principalTable: "Contacto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
