using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LojaVirtual.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCoupon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupon",
                columns: new[] { "id", "coupon_code", "discount_amount" },
                values: new object[,]
                {
                    { 1L, "RICHARD_10", 10m },
                    { 2L, "RICHARD_20", 20m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupon",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Coupon",
                keyColumn: "id",
                keyValue: 2L);
        }
    }
}
