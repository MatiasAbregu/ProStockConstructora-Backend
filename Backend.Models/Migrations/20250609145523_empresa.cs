using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class empresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Empresa",
                type: "varchar(120)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(120)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Empresa",
                type: "varchar(80)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(80)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "55c386f3-8615-400c-8308-97dff9975f66", null, "Superadministrador", "Superadministrador" },
                    { "5e157528-ef4f-43c4-b7f7-c08999d6fe20", null, "Administrador", "Administrador" },
                    { "7fdbc976-0a0a-4347-8b8b-c259eb9a7721", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "b6845be0-8bc8-47db-871c-ebbbc32427e1", null, "JefeDeObra", "JefeDeObra" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55c386f3-8615-400c-8308-97dff9975f66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e157528-ef4f-43c4-b7f7-c08999d6fe20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fdbc976-0a0a-4347-8b8b-c259eb9a7721");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6845be0-8bc8-47db-871c-ebbbc32427e1");

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Email",
                keyValue: null,
                column: "Email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Empresa",
                type: "varchar(120)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Celular",
                keyValue: null,
                column: "Celular",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Empresa",
                type: "varchar(80)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
