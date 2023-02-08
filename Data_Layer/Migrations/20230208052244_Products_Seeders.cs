using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductsSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "idCategoria", "estado", "nombre" },
                values: new object[,]
                {
                    { 1, 0, "Lacteos" },
                    { 2, 0, "Carnes" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "idProducto", "estado", "idCategoria", "nombre", "precio", "stock" },
                values: new object[,]
                {
                    { 1, 0, 1, "Leche", 10m, 0 },
                    { 2, 0, 1, "Queso", 20m, 0 },
                    { 3, 0, 2, "Carne de res", 30m, 0 },
                    { 4, 0, 2, "Carne de cerdo", 40m, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "idProducto",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "idProducto",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "idProducto",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "idProducto",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "idCategoria",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "idCategoria",
                keyValue: 2);
        }
    }
}
