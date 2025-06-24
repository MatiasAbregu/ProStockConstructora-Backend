using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class provinciaid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "366c5150-2062-472b-958e-6a88aedea46b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4453a854-b734-470c-a723-7925d61eae93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fcf5939-d79e-45b5-a338-eca92468b1c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feb4a263-2fd3-4b9e-955c-e7dfefba69be");

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Ubicaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fc5b617-6cb3-4387-bab3-d4b0af7e1d2e", null, "JefeDeObra", "JefeDeObra" },
                    { "3a6944b8-6157-4bf7-9bd9-8a990428777e", null, "Administrador", "Administrador" },
                    { "4d20b0a9-e49a-4d73-ab6a-4d7f346b69eb", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "e8b8050e-5ce3-4f84-b3b4-b98fc05bddb5", null, "Superadministrador", "Superadministrador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ubicaciones_ProvinciaId",
                table: "Ubicaciones",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ubicaciones_Provincias_ProvinciaId",
                table: "Ubicaciones",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ubicaciones_Provincias_ProvinciaId",
                table: "Ubicaciones");

            migrationBuilder.DropIndex(
                name: "IX_Ubicaciones_ProvinciaId",
                table: "Ubicaciones");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fc5b617-6cb3-4387-bab3-d4b0af7e1d2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a6944b8-6157-4bf7-9bd9-8a990428777e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d20b0a9-e49a-4d73-ab6a-4d7f346b69eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8b8050e-5ce3-4f84-b3b4-b98fc05bddb5");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Ubicaciones");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "366c5150-2062-472b-958e-6a88aedea46b", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "4453a854-b734-470c-a723-7925d61eae93", null, "Superadministrador", "Superadministrador" },
                    { "5fcf5939-d79e-45b5-a338-eca92468b1c6", null, "JefeDeObra", "JefeDeObra" },
                    { "feb4a263-2fd3-4b9e-955c-e7dfefba69be", null, "Administrador", "Administrador" }
                });
        }
    }
}
