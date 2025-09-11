using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.BD.Migrations
{
    /// <inheritdoc />
    public partial class corrigiendostockmaterialesmaquinasubicacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_TipoMateriales_TipoMaterialId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_UnidadMedidas_UnidadMedidaId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_TipoMaterialId",
                table: "Stocks");

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

            migrationBuilder.DropColumn(
                name: "CodigoISO",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "MaquinaId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "MaterialesId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "TipoMaterialId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "UbicacionId",
                table: "Obras");

            migrationBuilder.RenameColumn(
                name: "UnidadMedidaId",
                table: "Stocks",
                newName: "MaterialesyMaquinasId");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_UnidadMedidaId",
                table: "Stocks",
                newName: "IX_Stocks_MaterialesyMaquinasId");

            migrationBuilder.AddColumn<int>(
                name: "UbicacionId",
                table: "Depositos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MaterialesyMaquinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoISO = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    UnidadMedidaId = table.Column<int>(type: "int", nullable: true),
                    TipoMaterialId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialesyMaquinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialesyMaquinas_TipoMateriales_TipoMaterialId",
                        column: x => x.TipoMaterialId,
                        principalTable: "TipoMateriales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaterialesyMaquinas_UnidadMedidas_UnidadMedidaId",
                        column: x => x.UnidadMedidaId,
                        principalTable: "UnidadMedidas",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4afe7f97-518b-4beb-98a1-25826a882388", null, "JefeDeObra", "JefeDeObra" },
                    { "7ca87bea-28d1-45c9-9045-f03fa57c2664", null, "Administrador", "Administrador" },
                    { "bb3e9f41-07a9-4e0d-abcd-8982bd496631", null, "JefeDeDeposito", "JefeDeDeposito" },
                    { "e1ba79a5-1903-4657-ab9c-0d9d7a7e1740", null, "Superadministrador", "Superadministrador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obras_EmpresaId",
                table: "Obras",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_ObraId",
                table: "Depositos",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_UbicacionId",
                table: "Depositos",
                column: "UbicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesyMaquinas_TipoMaterialId",
                table: "MaterialesyMaquinas",
                column: "TipoMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesyMaquinas_UnidadMedidaId",
                table: "MaterialesyMaquinas",
                column: "UnidadMedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depositos_Obras_ObraId",
                table: "Depositos",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Depositos_Ubicaciones_UbicacionId",
                table: "Depositos",
                column: "UbicacionId",
                principalTable: "Ubicaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Empresa_EmpresaId",
                table: "Obras",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_MaterialesyMaquinas_MaterialesyMaquinasId",
                table: "Stocks",
                column: "MaterialesyMaquinasId",
                principalTable: "MaterialesyMaquinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depositos_Obras_ObraId",
                table: "Depositos");

            migrationBuilder.DropForeignKey(
                name: "FK_Depositos_Ubicaciones_UbicacionId",
                table: "Depositos");

            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Empresa_EmpresaId",
                table: "Obras");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_MaterialesyMaquinas_MaterialesyMaquinasId",
                table: "Stocks");

            migrationBuilder.DropTable(
                name: "MaterialesyMaquinas");

            migrationBuilder.DropIndex(
                name: "IX_Obras_EmpresaId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Depositos_ObraId",
                table: "Depositos");

            migrationBuilder.DropIndex(
                name: "IX_Depositos_UbicacionId",
                table: "Depositos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4afe7f97-518b-4beb-98a1-25826a882388");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ca87bea-28d1-45c9-9045-f03fa57c2664");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb3e9f41-07a9-4e0d-abcd-8982bd496631");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1ba79a5-1903-4657-ab9c-0d9d7a7e1740");

            migrationBuilder.DropColumn(
                name: "UbicacionId",
                table: "Depositos");

            migrationBuilder.RenameColumn(
                name: "MaterialesyMaquinasId",
                table: "Stocks",
                newName: "UnidadMedidaId");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_MaterialesyMaquinasId",
                table: "Stocks",
                newName: "IX_Stocks_UnidadMedidaId");

            migrationBuilder.AddColumn<string>(
                name: "CodigoISO",
                table: "Stocks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "MaquinaId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaterialesId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Stocks",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TipoMaterialId",
                table: "Stocks",
                type: "int",
                nullable: true);

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
                    { "1a427d4d-ed4b-4412-9054-d043f9d35e75", null, "Superadministrador", "Superadministrador" },
                    { "52c232a7-09a3-4f7a-8e05-3eea6246306c", null, "JefeDeObra", "JefeDeObra" },
                    { "bb6dc87c-a552-4823-b27f-899a430141b8", null, "Administrador", "Administrador" },
                    { "d1ba1d6a-fa3b-431e-8d41-73d16a3bacd3", null, "JefeDeDeposito", "JefeDeDeposito" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_TipoMaterialId",
                table: "Stocks",
                column: "TipoMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_TipoMateriales_TipoMaterialId",
                table: "Stocks",
                column: "TipoMaterialId",
                principalTable: "TipoMateriales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_UnidadMedidas_UnidadMedidaId",
                table: "Stocks",
                column: "UnidadMedidaId",
                principalTable: "UnidadMedidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
