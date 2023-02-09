using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UsersDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Usuarios_id_Vendedor",
                table: "Ventas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_id_Vendedor",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "id_Vendedor",
                table: "Ventas");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "idProducto",
                keyValue: 1,
                columns: new[] { "estado", "stock" },
                values: new object[] { 1, 10 });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "idProducto",
                keyValue: 2,
                columns: new[] { "estado", "stock" },
                values: new object[] { 1, 10 });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "idProducto",
                keyValue: 3,
                columns: new[] { "estado", "stock" },
                values: new object[] { 1, 10 });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "idProducto",
                keyValue: 4,
                columns: new[] { "estado", "stock" },
                values: new object[] { 1, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_Vendedor",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoUsuarios",
                columns: table => new
                {
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarios", x => x.idTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTipoUsuario = table.Column<int>(name: "id_TipoUsuario", type: "int", nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuarios_id_TipoUsuario",
                        column: x => x.idTipoUsuario,
                        principalTable: "TipoUsuarios",
                        principalColumn: "idTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "idProducto",
                keyValue: 1,
                columns: new[] { "estado", "stock" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "idProducto",
                keyValue: 2,
                columns: new[] { "estado", "stock" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "idProducto",
                keyValue: 3,
                columns: new[] { "estado", "stock" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "idProducto",
                keyValue: 4,
                columns: new[] { "estado", "stock" },
                values: new object[] { 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_id_Vendedor",
                table: "Ventas",
                column: "id_Vendedor");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_id_TipoUsuario",
                table: "Usuarios",
                column: "id_TipoUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Usuarios_id_Vendedor",
                table: "Ventas",
                column: "id_Vendedor",
                principalTable: "Usuarios",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
