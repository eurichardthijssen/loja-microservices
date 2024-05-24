using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LojaVirtual.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 3L, "Lapis", "Melhor lapis que existe", "https://http2.mlstatic.com/D_NQ_NP_971577-MLB44653901933_012021-O.webp", "Lapis", 29.9m },
                    { 4L, "Lapis", "Melhor lapis que existe 4", "https://http2.mlstatic.com/D_NQ_NP_971577-MLB44653901933_012021-O.webp", "Lapis 4", 29.9m },
                    { 5L, "Lapis", "Melhor lapis que existe 5", "https://http2.mlstatic.com/D_NQ_NP_971577-MLB44653901933_012021-O.webp", "Lapis 5", 39.9m },
                    { 6L, "Lapis", "Melhor lapis que existe 6", "https://http2.mlstatic.com/D_NQ_NP_971577-MLB44653901933_012021-O.webp", "Lapis 6", 49.9m },
                    { 7L, "Lapis", "Melhor lapis que existe 7", "https://http2.mlstatic.com/D_NQ_NP_971577-MLB44653901933_012021-O.webp", "Lapis 7", 59.9m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 7L);
        }
    }
}
