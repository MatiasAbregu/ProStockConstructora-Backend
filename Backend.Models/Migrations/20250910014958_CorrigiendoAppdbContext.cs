using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class CorrigiendoAppdbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00191701-0412-4dd9-8d58-8b226e6775f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "101d3764-c6fb-499f-b7b4-31f0f6fbae5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b4b2a59-500a-45e8-974d-861c2b0b63a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb30781c-3df7-4d5f-b1e5-1382b783d190");

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UnidadMedidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Simbolo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMedidas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaIngreso = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CodigoISO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoMaterialId = table.Column<int>(type: "int", nullable: true),
                    MaterialesId = table.Column<int>(type: "int", nullable: false),
                    MaquinaId = table.Column<int>(type: "int", nullable: false),
                    UnidadMedidaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Materiales_TipoMaterialId",
                        column: x => x.TipoMaterialId,
                        principalTable: "Materiales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stocks_UnidadMedidas_UnidadMedidaId",
                        column: x => x.UnidadMedidaId,
                        principalTable: "UnidadMedidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_TipoMaterialId",
                table: "Stocks",
                column: "TipoMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_UnidadMedidaId",
                table: "Stocks",
                column: "UnidadMedidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "UnidadMedidas");

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
                    { "00191701-0412-4dd9-8d58-8b226e6775f7", null, "Administrador", "Administrador" },
                    { "101d3764-c6fb-499f-b7b4-31f0f6fbae5f", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "7b4b2a59-500a-45e8-974d-861c2b0b63a5", null, "Superadministrador", "Superadministrador" },
                    { "bb30781c-3df7-4d5f-b1e5-1382b783d190", null, "JefeDeObra", "JefeDeObra" }
                });
        }
    }
}
