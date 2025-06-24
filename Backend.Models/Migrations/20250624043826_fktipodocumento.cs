using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class fktipodocumento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumentoId",
                table: "Documentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45f89728-71df-4af0-baf2-bf7465181c05", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "99fe98da-4554-4652-b518-fad0234e5ea1", null, "Superadministrador", "Superadministrador" },
                    { "c2680b6d-2fb4-4859-a568-cb203fa38d6d", null, "Administrador", "Administrador" },
                    { "ef7b65c4-110c-4205-9ef2-039ea402dff7", null, "JefeDeObra", "JefeDeObra" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_TipoDocumentoId",
                table: "Documentos",
                column: "TipoDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_TipoDocumentos_TipoDocumentoId",
                table: "Documentos",
                column: "TipoDocumentoId",
                principalTable: "TipoDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_TipoDocumentos_TipoDocumentoId",
                table: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_TipoDocumentoId",
                table: "Documentos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45f89728-71df-4af0-baf2-bf7465181c05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99fe98da-4554-4652-b518-fad0234e5ea1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2680b6d-2fb4-4859-a568-cb203fa38d6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef7b65c4-110c-4205-9ef2-039ea402dff7");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoId",
                table: "Documentos");

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
        }
    }
}
