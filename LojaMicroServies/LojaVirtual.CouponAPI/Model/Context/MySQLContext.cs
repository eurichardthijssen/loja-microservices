using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.CouponAPI.Model.Context
{
    public class MySQLContext : DbContext
    {

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 1,
                CouponCode = "RICHARD_10",
                DiscountAmount = 10,
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 2,
                CouponCode = "RICHARD_20",
                DiscountAmount = 20,
            });
        }
    }
}
