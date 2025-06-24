using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class fkubicacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ubicaciones_Obras_ObraId",
                table: "Ubicaciones");

            migrationBuilder.DropIndex(
                name: "IX_Ubicaciones_ObraId",
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
                name: "ObraId",
                table: "Ubicaciones");

            migrationBuilder.AddColumn<int>(
                name: "UbicacionId",
                table: "Obras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "91d23469-833c-4dfa-ba68-4458349c8bdd", null, "JefeDeObra", "JefeDeObra" },
                    { "bd24c165-a67d-4402-a417-b3e96eea4011", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "f8ccb213-0197-47ae-ac8e-f84940a07434", null, "Superadministrador", "Superadministrador" },
                    { "f9dc7939-a5af-4701-8511-b7ffd5901a73", null, "Administrador", "Administrador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obras_UbicacionId",
                table: "Obras",
                column: "UbicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Ubicaciones_UbicacionId",
                table: "Obras",
                column: "UbicacionId",
                principalTable: "Ubicaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Ubicaciones_UbicacionId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Obras_UbicacionId",
                table: "Obras");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91d23469-833c-4dfa-ba68-4458349c8bdd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd24c165-a67d-4402-a417-b3e96eea4011");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8ccb213-0197-47ae-ac8e-f84940a07434");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9dc7939-a5af-4701-8511-b7ffd5901a73");

            migrationBuilder.DropColumn(
                name: "UbicacionId",
                table: "Obras");

            migrationBuilder.AddColumn<int>(
                name: "ObraId",
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
                name: "IX_Ubicaciones_ObraId",
                table: "Ubicaciones",
                column: "ObraId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ubicaciones_Obras_ObraId",
                table: "Ubicaciones",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
